using System;

namespace Connect4Library
{
    public class Board
    {
        public const int IndexMaxRows = 5, CountMaxRows = 6;
        public const int IndexMaxCols = 6, CountMaxCols = 7;

        private readonly int?[,] board = new int?[CountMaxRows, CountMaxCols];

        public int? this[int row, int col]
        {
            get => this.board[row, col];
            set => this.board[row, col] = value;
        }

        public void PlaceDisk(Location location, int value)
        {
            if (location != null)
                this.board[location.Row, location.Column] = value;
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
            if (board[rowIndex, colIndex] == null)
                return new Location(rowIndex, colIndex);

            return null;
        }
    }
}