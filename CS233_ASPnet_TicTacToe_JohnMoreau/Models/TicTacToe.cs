namespace CS233_ASPnet_TicTacToe_JohnMoreau.Models
{
    public class TicTacToe
    {
        public int LastId { get; set; } = 9;
        public string CurrentPlayer { get; set; } = "X";
        public bool GameOver { get; set; } = false;
        public string Wins { get; set; } = "";

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

        // public string BoardString { get; set; } = string.Empty;

        //public TicTacToe()
        //{

        //}

        //public TicTacToe(string[] board, string currentPlayer, int lastId)
        //{
        //    Board = board;
        //    CurrentPlayer = currentPlayer;
        //    LastId = lastId;
            
        //}


        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        }

        public TicTacToe Restart()
        {
            var game = new TicTacToe();
            game.Wins = Wins;
            return game;
        }


        public void CheckForWin()
        {
            //if (CheckPattern(Board, 0, Board.Length, 3, 1)  // Check Rows
            //    || CheckPattern(Board, 0, Board.Length, 1, 3) // Check Columns
            //    || CheckPattern(Board, 0, Board.Length, 2, 4) // Check left to right cross
            //    || CheckPattern(Board, 2, 6, 2, 2)) // Check right to left cross
            //{
            //    GameOver = true;
            //    PushWin();
            //};
            if (CheckPattern(Board, 0, Board.Length, 3, 1)  // Check Rows
                || CheckPattern(Board, 0, Board.Length, 1, 3) // Check Columns
                || CheckPattern(Board, 0, Board.Length, 2, 4) // Check left to right cross
                || CheckPattern(Board, 2, 6, 2, 2)) // Check right to left cross
            {
                GameOver = true;
                PushWin();
            };
        }

        public void PushWin()
        {
            if (!string.IsNullOrEmpty(Wins) && Wins.Length > 0)
            {
                Wins += ", " + CurrentPlayer;
            }
            else
            {
                Wins = CurrentPlayer;
            }
        }


        private static bool CheckPattern(string[] board, int start, int end, int outerIncrement, int innerIncrement)
        {


            // Check Row Wins
            for (int i = start; i < end; i += outerIncrement)
            {
                var position = "";
                var matchCount = 0;

                if (i >= board.Length)
                {
                    return false;
                }

                for (int j = i; j < end; j += innerIncrement)
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

    //private static bool CheckPattern(string[] board, int start, int end, int outerIncrement, int innerIncrement)
    //{


    //    // Check Row Wins
    //    for (int i = start; i < end; i += outerIncrement)
    //    {
    //        var position = "";
    //        var matchCount = 0;

    //        if (i >= board.Length)
    //        {
    //            return false;
    //        }

    //        for (int j = i; j < end; j += innerIncrement)
    //        {
    //            if (j >= board.Length)
    //            {
    //                return false;
    //            }
    //            var lastPosition = position;
    //            position = board[j];
    //            if (position != "X" && position != "O")
    //            {
    //                continue;
    //            }

    //            if (lastPosition == position)
    //            {
    //                matchCount++;
    //                if (matchCount >= 2)
    //                {
    //                    return true;
    //                }
    //            }
    //            else
    //            {
    //                matchCount = 0;
    //            }
    //        }

    //    }

    //    return false;

    //}


}
}
