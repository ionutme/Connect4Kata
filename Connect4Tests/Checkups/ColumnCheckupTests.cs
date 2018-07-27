using Connect4Library;
using NUnit.Framework;

namespace Connect4Tests.Checkups
{
    [TestFixture]
    public class ColumnCheckupTests : CheckupTests
    {
        [Test]
        [TestOf(typeof(ColumnCheckup))]
        public void Has4Hits_WhenFistColumnHas4SameDisks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnColumn(4, 0, board, Game.Player.One);
            PlaceDisksOnColumn(3, 1, board, Game.Player.Two);

            var columnCheckup = new ColumnCheckup(board);

            Assert.IsTrue(columnCheckup.Has4Hits((int)Game.Player.One));
        }

        [Test]
        [TestOf(typeof(ColumnCheckup))]
        public void Has4Hits_WhenFistColumnHas1stDiskDifferentFollowedBy4SameDisks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnColumn(1, 0, board, Game.Player.Two);
            PlaceDisksOnColumn(4, 0, board, Game.Player.One, 1);

            var columnCheckup = new ColumnCheckup(board);

            Assert.IsTrue(columnCheckup.Has4Hits((int)Game.Player.One), GetBoardPrint(board));
        }

        [Test]
        [TestOf(typeof(ColumnCheckup))]
        public void Has4Hits_WhenFistColumnHas2ndDiskDifferentFromTheRest_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnColumn(1, 0, board, Game.Player.One);
            PlaceDisksOnColumn(1, 0, board, Game.Player.Two, 1);
            PlaceDisksOnColumn(4, 0, board, Game.Player.One, 2);

            var columnCheckup = new ColumnCheckup(board);

            Assert.IsTrue(columnCheckup.Has4Hits((int)Game.Player.One), GetBoardPrint(board));
        }
    }
}