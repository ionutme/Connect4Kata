using System;
using Connect4Library;
using NUnit.Framework;

namespace Connect4Tests.Checkups
{
    [TestFixture]
    public class RowCheckupTests : CheckupTests
    {
        [Test]
        [TestOf(typeof(RowCheckup))]
        public void Has4Hits_WhenFirstRowHas4SameDisks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnRow(4, Board.IndexMaxRows, board, Game.Player.One);

            var rowCheckup = new RowCheckup(board);

            Assert.IsTrue(rowCheckup.Has4Hits((int) Game.Player.One));
        }

        [Test]
        [TestOf(typeof(RowCheckup))]
        public void Has4Hits_WhenFistRowHas1stDiskDifferentFollowedBy4SameDisks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnRow(1, Board.IndexMaxRows, board, Game.Player.Two);
            PlaceDisksOnRow(4, Board.IndexMaxRows, board, Game.Player.One, 1);

            var rowCheckup = new RowCheckup(board);

            Assert.IsTrue(rowCheckup.Has4Hits((int)Game.Player.One));
        }

        [Test]
        [TestOf(typeof(RowCheckup))]
        public void Has4Hits_WhenFistRowHasThe2ndDiskDifferentFromTheRest_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnRow(1, Board.IndexMaxRows, board, Game.Player.One);
            PlaceDisksOnRow(1, Board.IndexMaxRows, board, Game.Player.Two, 1);
            PlaceDisksOnRow(4, Board.IndexMaxRows, board, Game.Player.One, 2);

            var rowCheckup = new RowCheckup(board);

            Assert.IsTrue(rowCheckup.Has4Hits((int)Game.Player.One));

            Console.WriteLine(GetBoardPrint(board));
        }
    }
}