using System;

namespace Connect4Library
{
    public class Game
    {
        public readonly Board Board;
        public readonly BoardCheckup BoardCheckup;
        private bool isGameOver = false;
        private int currentPlayer = 1;

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

            Board.PlaceDisk(location, this.currentPlayer);

            if (BoardCheckup.IsConnect4(this.currentPlayer))
                return $"Player {this.currentPlayer} wins!";
            
            return ChangeTurn();
        }

        public string ChangeTurn()
        {
            int previousPlayer = this.currentPlayer;
            if (previousPlayer == 1)
                this.currentPlayer = 2;
            else
                this.currentPlayer = 1;

            return $"Player {previousPlayer} has a turn";
        }
    }
}
