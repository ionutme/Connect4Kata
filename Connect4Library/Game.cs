using System;

namespace Connect4Library
{
    public class Game
    {
        public readonly GameBoard Board;
        private bool _isConnect4 = false;
        private int _currentPlayer;
        private Tuple<int, int> _currentPosition;

        public Game()
        {
            Board = new GameBoard();
            _currentPlayer = 1;
        }

        public string play(int col)
        {
            if (_isConnect4) return "Game has finished.";
            if (!CanPlaceDiscToColumn(col)) return "Column full!";
            
            PlaceDiscToColumn(col);

            var currentPlayer = _currentPlayer;
            if (IsConnect4())
                return $"Player {currentPlayer} wins!";
            else
                ChangeTurn();   //change current player

            return $"Player {currentPlayer} has a turn";
        }

        private bool IsConnect4()
        {
            _isConnect4 =  IsRowStrike() ||
                           IsColStrike() ||
                           IsDiagonalStrike();
            
            return _isConnect4;
        }

        private bool IsRowStrike()
        {
            for (var row = 0; row < 6; row++)
            {
                var countSame = 0;
                for (var col = 0; col < 7; col++)
                {
                    if (Board[row, col] == _currentPlayer)
                        countSame++;
                    else if (countSame > 0)
                        countSame = 0;
                }

                if (countSame >= 4)
                    return true;
            }

            return false;
        }

        private bool IsColStrike()
        {
            for (var col = 0; col < 7; col++)
            {
                var countSame = 0;
                for (var row = 5; row >= 0; row--)
                {
                    if (Board[row, col] == _currentPlayer)
                        countSame++;
                    else if (countSame > 0)
                        countSame = 0;
                }

                if (countSame >= 4)
                    return true;
            }

            return false;
        }

        private bool IsDiagonalStrike()
        {
            int _diagStrikes;
            for (int col=0; col<7; col++)
            {
                for (int row=0; row<6; row++)
                {
                    _diagStrikes = 0;

                    if (Board[row, col] == _currentPlayer)
                    {
                        _diagStrikes++;

                        int nextRow = row+1;                        
                        int nextCol = col+1;
                        while(nextRow < 6 && nextCol < 7 &&
                              Board[nextRow,nextCol] == _currentPlayer)
                        {
                            _diagStrikes++;
                            
                            nextRow++;
                            nextCol++;
                        }

                        if (_diagStrikes >= 4)
                            return true;
                    }
                }
            }

            return false;
        }

        private void PlaceDiscToColumn(int col)
        {
            for (var i = 5; i >= 0; i--)
                if (Board[i, col] == null)
                {
                    Board[i, col] = _currentPlayer;
                    
                    _currentPosition = new Tuple<int, int>(i, col);
                    
                    return;
                }
        }

        private bool CanPlaceDiscToColumn(int col)
        {
            for (var i = 5; i >= 0; i--)
                if (Board[i, col] == null)
                    return true;

            return false;
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
