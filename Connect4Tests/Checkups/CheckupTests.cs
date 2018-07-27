using System.Text;
using Connect4Library;
using Connect4Library.GameBoard;

namespace Connect4Tests.Checkups
{
    public abstract class CheckupTests
    {
        protected void PlaceDisksOnColumn(int count, int col, Board board, Game.Player player, int dx = 0)
        {
            var lowestIndex = Board.CountMaxRows - (count + dx);
            if (lowestIndex > Board.IndexMaxRows)
                throw new System.IndexOutOfRangeException(nameof(count));

            for (int row = Board.IndexMaxRows-dx; row >= lowestIndex; row--)
                PlaceDisk(row, col, board, player);
        }

        protected void PlaceDisksOnRow(int count, int row, Board board, Game.Player player, int dx = 0)
        {
            var lowestIndex = count - 1 + dx;
            if (lowestIndex > Board.IndexMaxCols)
                throw new System.IndexOutOfRangeException(nameof(count));

            for (int col = dx; col <= lowestIndex; col++)
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