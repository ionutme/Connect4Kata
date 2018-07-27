using System.Text;
using Connect4Library;
using Connect4Library.GameBoard;

namespace Connect4Tests.Checkups
{
    public abstract class CheckupTests
    {
        protected void PlaceDisksOnColumn(int count, int col, Board board, Game.Player player, int deviation = 0)
        {
            if (count + deviation > Board.CountMaxRows)
                throw new System.IndexOutOfRangeException(nameof(count));

            var rowsIndexBoundary = Board.CountMaxRows - (count + deviation);
            for (int row = Board.IndexMaxRows-deviation; row >= rowsIndexBoundary; row--)
                PlaceDisk(row, col, board, player);
        }
        protected void PlaceDisksOnRow(int count, int row, Board board, Game.Player player, int deviation = 0)
        {
            if (count + deviation > Board.CountMaxCols)
                throw new System.IndexOutOfRangeException(nameof(count));

            var colsIndexBoundary = Board.CountMaxCols - (count + deviation);
            for (int col=0 + deviation; col <= colsIndexBoundary; col++)
                PlaceDisk(row, col, board, player);
        }

        protected static string GetBoardPrint(Board board)
        {
            var boardPrint = new StringBuilder().AppendLine("THE BOARD");

            board.Print(value => boardPrint.Append(value));

            return boardPrint.ToString();
        }

        private static void PlaceDisk(int row, int col, Board board, Game.Player player)
        {
            board.PlaceDisk(new Location(row, col), (int) player);
        }
    }
}