using NUnit.Framework;
using Connect4Library;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var game = new Game();

            var message = game.play(0);

            Assert.AreEqual("Player 1 has a turn", message);
        }
    }
}