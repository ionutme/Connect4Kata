using System;

namespace Connect4Library
{
    public class Game
    {
        public readonly Board Board;
        public readonly BoardCheckup BoardCheckup;
        private bool _isConnect4 = false;
        private int _currentPlayer;
        private Tuple<int, int> _currentPosition;

        public Game()
        {
            Board = new Board();
            BoardCheckup = new BoardCheckup(Board);

            _currentPlayer = 1;
        }

        // ? Command patter
        // ! Should be Play with cappital P
        // TODO: refactoring
        public string play(int col)
        {
            if (_isConnect4) return "Game has finished.";
            var currentPlayer = _currentPlayer;

            var location = Board.GetNextAvailable(col);
            if (Board.IsAvailable(location))
                Board.PlaceDisk(location, currentPlayer);
            else return "Column full!";

            if (BoardCheckup.IsConnect4(currentPlayer))
                return $"Player {currentPlayer} wins!";
            else
                ChangeTurn();   //change current player

            return $"Player {currentPlayer} has a turn";
        }

        public void ChangeTurn()
        {
            if (_currentPlayer == 1)
            {
                _currentPlayer = 2;
                return;
            }

            _currentPlayer = 1;
        }
    }
}
