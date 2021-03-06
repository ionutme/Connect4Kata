using Connect4Library;
using NUnit.Framework;

namespace Connect4Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Play_WhenPlacingDiskOnColumn_ThenGameBoardSaveDiskPositionOnExpectedLocation()
        {
            var game = new Game();

            Assert.IsTrue(game.Board.IsAvailable(5,3));

            // Act
            var message = game.play(3);

            Assert.IsFalse(game.Board.IsAvailable(5, 3), "The location were the disk is placed should not be available anymore.");
        }

        [Test]
        public void Play_WhenPlacingTheFirstDisk_ReturnsPlayerOneHasATurnMessage()
        {
            var game = new Game();

            var message = game.play(0); // Player 1 has a turn

            Assert.AreEqual("Player 1 has a turn", message);
        }

        [Test]
        public void Play_WhenPlacingTheSecondDisk_ReturnsPlayerTwoHasATurnMessage()
        {
            var game = new Game();

            game.play(0);               // Player 1 has a turn
            var message = game.play(0); // Player 2 has a turn

            Assert.AreEqual("Player 2 has a turn", message);
        }

        [Test]
        public void Play_WhenPlacingDiskToFullColumn_ReturnsColumnFullErrorMessage()
        {
            var game = new Game();

            game.play(0);               // 1. Player 1 has a turn
            game.play(0);               // 2. Player 2 has a turn
            game.play(0);               // 3. Player 1 has a turn
            game.play(0);               // 4. Player 2 has a turn
            game.play(0);               // 5. Player 1 has a turn
            game.play(0);               // 6. Player 2 has a turn
            var message = game.play(0); // 7. Player 1 has a turn

            Assert.AreEqual("Column full!", message);
        }
    }
}