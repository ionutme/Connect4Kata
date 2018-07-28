using System;
using Connect4Library;
using NUnit.Framework;

namespace Connect4Tests.Checkups
{
    [TestFixture]
    public class DiagonalCheckupTests : CheckupTests
    {
        [Test]
        [TestOf(typeof(DiagonalCheckup))]
        public void Has4Hits_WhenDiagonalHas4SameDisks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnDiagonal(4, board, Game.Player.One);

            var diagonalCheckup = new DiagonalCheckup(board);

            Assert.IsTrue(diagonalCheckup.Has4Hits((int)Game.Player.One));

            Console.WriteLine(GetBoardPrint(board));
        }
        [Test]
        [TestOf(typeof(DiagonalCheckup))]
        public void Has4Hits_WhenDiagonalHas1stDiskDifferentFromTheRest_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnDiagonal(1, board, Game.Player.Two);
            PlaceDisksOnDiagonal(4, board, Game.Player.One, 1);

            var diagonalCheckup = new DiagonalCheckup(board);

            Assert.IsTrue(diagonalCheckup.Has4Hits((int)Game.Player.One), GetBoardPrint(board));

            Console.WriteLine(GetBoardPrint(board));
        }
    }
}