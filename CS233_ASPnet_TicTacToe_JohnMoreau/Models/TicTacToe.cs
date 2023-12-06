namespace CS233_ASPnet_TicTacToe_JohnMoreau.Models
{
    public class TicTacToe
    {
        public int LastId { get; set; } = 9;
        public string CurrentPlayer { get; set; } = "X";
        public bool GameOver { get; set; } = false;

        public string[] Board { get; set; } = [
                " ",
            " ",
            " ",
            " ",
            "O",
            " ",
            " ",
            " ",
            "X",
        ];

        public string BoardString { get; set; } = string.Empty;

        public TicTacToe()
        {

        }

        public TicTacToe(string[] board, string currentPlayer, int lastId)
        {
            Board = board;
            CurrentPlayer = currentPlayer;
            LastId = lastId;
            
        }


        public static string[] InitializeBoard()
        {
            return [
                " ", " ", " ",
                " ", "O", " ",
                " ", " ", "X",
            ];
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        }

        public static bool CheckForWin(string[] board)
        {

            // Check Rows
            if (CheckPattern(board, 1, board.Length, 3, 1)) return true;

            // Check Columns
            if (CheckPattern(board, 1, board.Length, 1, 3)) return true;

            // Check left to right cross
            if (CheckPattern(board, 1, board.Length, 2, 4)) return true;

            // Check right to left cross
            if (CheckPattern(board, 2, 6, 2, 2)) return true; ;

            return false;
        }


        private static bool CheckPattern(string[] board, int start, int end, int startingIncrement, int patternIncrement)
        {
            var position = "";
            var matchCount = 0;

            // Check Row Wins
            for (int i = start; i < end; i += startingIncrement)
            {
                if (i >= board.Length)
                {
                    return false;
                }

                for (int j = i; j < board.Length; j += patternIncrement)
                {
                    if (j >= board.Length)
                    {
                        return false;
                    }
                    var lastPosition = position;
                    position = board[i];


                    if (lastPosition == position)
                    {
                        matchCount++;
                        if (matchCount >= 3)
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
