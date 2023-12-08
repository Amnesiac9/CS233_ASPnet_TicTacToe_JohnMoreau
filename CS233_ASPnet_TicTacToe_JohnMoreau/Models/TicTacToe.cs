/*
* John Moreau
* CSS233
* 12/7/2023
*/

namespace CS233_ASPnet_TicTacToe_JohnMoreau.Models
{
    public class TicTacToe
    {
        public int LastId { get; set; } = 9;
        public string CurrentPlayer { get; set; } = "X";
        public bool GameOver { get; set; } = false;

        public bool Tie { get; set; } = false;
        public string History { get; set; } = "";

        public string[] Board { get; set; } = [
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
            "-",
        ];

        private static int CharCount(string str, char s)
        {
            if (str == null) return 0;

            int count = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == s)
                    count++;
            }
            return count;
        }

        public string GetWinCount(char s)
        {
            return CharCount(History, s).ToString();
        }


        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        }

        public void PushWinOrTie()
        {
            var str = Tie ? "Tie" : CurrentPlayer;
            History = string.IsNullOrWhiteSpace(History) ? str : History + ", " + str;
        }

        public TicTacToe Restart()
        {
            var game = new TicTacToe();
            game.History = History;
            return game;
        }


        public void CheckForWinOrTie()
        {

            
            if (CheckPattern(Board, 0, 3, 3, 1, 3)  // Check Rows // Start at 0, increment outer loop by 3 (Check 3 at a time), then iterate inner loop by 1 (Check left to right) inner end would be start + 3, outer end would be board.length
                || CheckPattern(Board, 0, 1, 3, 3, 3) // Check Columns // Start at 0, increment outer loop by 1 (Check top to bottom) then iterate inner loop by 3 (Checking 3 at a time), inner end would be board.length (9), outer end would be 3.
                || CheckPattern(Board, 0, 2, 1, 4, 3) // Check left to right cross // Start at 0, outerloop only needs to run once.
                || CheckPattern(Board, 2, 7, 1, 2, 3)) // Check right to left cross // Start at 2, outerloop only needs to run once.
            {
                GameOver = true;
                PushWinOrTie();
            }
            else if (!Board.Contains("-"))
            {
                GameOver = true;
                Tie = true;
                PushWinOrTie();
            }
        }


        // I know I could have hard coded each win condition, but this was fun. =)
        // CheckPattern traverses a grid using a start index, outerIncrement (How much the outer loop should increment), outerRunCount (How many times the outer loop should run)
        private static bool CheckPattern(string[] board, int startIndex, int outerIncrement, int outerRunCount, int innerIncrement, int innerRunCount)
        {

            // Start at our start index, increment by the outerIncrement, and loop while i is < how much we should increment * how many times.
            for (int i = startIndex; i < outerIncrement*outerRunCount; i += outerIncrement)
            {
                var position = "";
                var matchCount = 0;

                if (i >= board.Length)
                {
                    return false;
                }

                // start at the current i, increment by innerIncrement, and loop while j is < our current index + how much we should increment * how many times.
                for (int j = i; j < i + innerIncrement*innerRunCount; j += innerIncrement)
                {
                    if (j >= board.Length)
                    {
                        return false;
                    }
                    var lastPosition = position;
                    position = board[j];
                    if (position != "X" && position != "O")
                    {
                        continue;
                    }

                    if (lastPosition == position)
                    {
                        matchCount++;
                        if (matchCount >= 2)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        matchCount = 0;
                    }
                }
                
            }

            return false;

        }


    }

}
