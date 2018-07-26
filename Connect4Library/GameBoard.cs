namespace Connect4Library
{
    public class GameBoard
    {
        public GameBoard()
        {            
        }

        private int?[,] _board = new int?[6, 7];

        public int? this[int row, int col]
        {
            get{return _board[row, col];}
            set{_board[row, col] = value;}
        }
    }
}