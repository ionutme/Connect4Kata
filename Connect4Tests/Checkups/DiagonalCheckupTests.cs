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
        public void Has4Hits_WhenFistDiagonalHas4SameDisks_ReturnsTrue()
        {
            var board = new Board();
            PlaceDisksOnDiagonal(4, board, Game.Player.One);

            var diagonalCheckup = new DiagonalCheckup(board);

            Assert.IsTrue(diagonalCheckup.Has4Hits((int)Game.Player.One));

            Console.WriteLine(GetBoardPrint(board));
        }
    }
}