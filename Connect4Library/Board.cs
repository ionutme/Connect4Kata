using System;

namespace Connect4Library
{
    public class Board
    {
        public const int IndexMaxRows = 5, CountMaxRows = 6;
        public const int IndexMaxCols = 6, CountMaxCols = 7;

        private int?[,] _board = new int?[CountMaxRows, CountMaxCols];

        public int? this[int row, int col]
        {
            get { return _board[row, col]; }
            set { _board[row, col] = value; }
        }

        public void PlaceDisk(Location location, int value)
        {
            if (location != null)
                this._board[location.Row, location.Column] = value;
        }

        public bool IsAvailable(int colIndex)
        {
            return IsAvailable(GetNextAvailable(colIndex));
        }

        public bool IsAvailable(int rowIndex, int colIndex)
        {
            return IsAvailable(GetAvailable(rowIndex, colIndex));
        }

        public bool IsAvailable(Location location)
        {
            return location != null;
        }

        public Location GetNextAvailable(int colIndex)
        {
            Location location = null;
            var rowIndex = IndexMaxRows;

            while (rowIndex >= 0 && location == null)
            {
                location = GetAvailable(rowIndex, colIndex);

                rowIndex--;
            }

            return location;
        }

        public Location GetAvailable(int rowIndex, int colIndex)
        {
            if (_board[rowIndex, colIndex] == null)
                return new Location(rowIndex, colIndex);

            return null;
        }

        public int? GetValue(int rowIndex, int colIndex)
        {
            return _board[rowIndex, colIndex];
        }
    }
}