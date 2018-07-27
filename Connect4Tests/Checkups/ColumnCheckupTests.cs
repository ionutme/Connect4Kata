using NUnit.Framework;
using Connect4Library;

namespace Tests
{
    [TestFixture]
    public class ColumnCheckupTests
    {
        [Test]
        public void Has4Hits_WhenFistColumnHas4Disks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisks(4, 0, board, Game.Player.One);
            PlaceDisks(3, 1, board, Game.Player.Two);

            var columnCheckup = new ColumnCheckup(board);

            Assert.IsTrue(columnCheckup.Has4Hits((int)Game.Player.One));
        }

        private void PlaceDisks(int count, int col, Board board, Game.Player player)
        {
            if (count-1 > Board.IndexMaxRows)
                throw new System.IndexOutOfRangeException(nameof(count));

            for (int row=Board.IndexMaxRows; row >= Board.CountMaxRows - count; row--)
            {
                board.PlaceDisk(new Location(row, col), (int)player);
            }
        }
    }
}