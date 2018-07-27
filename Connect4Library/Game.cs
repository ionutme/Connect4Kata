using System;

namespace Connect4Library
{
    public class Game
    {
        public readonly Board Board;
        public readonly BoardCheckup BoardCheckup;
        private bool isGameOver = false;
        public enum Player {One = 1, Two = 2};
        private Player currentPlayer = Player.One;

        public Game()
        {
            Board = new Board();
            BoardCheckup = new BoardCheckup(Board);
        }
        
        public string play(int col)
        {
            if (this.isGameOver)
                return "Game has finished.";

            var location = Board.GetNextAvailable(col);
            if (!Board.IsAvailable(location))
                return "Column full!";

            Board.PlaceDisk(location, (int)this.currentPlayer);

            if (BoardCheckup.IsConnect4((int)this.currentPlayer))
                return $"Player {(int)this.currentPlayer} wins!";
            
            return ChangeTurn();
        }

        public string ChangeTurn()
        {
            var previousPlayer = this.currentPlayer;
            if (previousPlayer == Player.One)
                this.currentPlayer = Player.Two;
            else
                this.currentPlayer = Player.One;

            return $"Player {(int)previousPlayer} has a turn";
        }
    }
}
