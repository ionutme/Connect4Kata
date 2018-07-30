using System;

namespace CodeWars
{
    class Connect4
    {
        private readonly int?[,] Board = new int?[6, 7];
        private int _currentPlayer;
        private bool _isConnect4 = false;
        private Tuple<int, int> _currentPosition;

        public Connect4()
        {
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
            int maxHits = 0;

            for (var row = 0; row <= 5; row++)
            {
                maxHits = 0;

                int hits = 0;
                int col = 0;
                while (col <= 6)
                {
                    if (Board[row, col] == _currentPlayer)
                    {
                        hits++;
                    }
                    else
                    {
                        maxHits = Math.Max(maxHits, hits);
                        hits = 0;
                    }

                    col++;  // move to the next column
                }

                maxHits = Math.Max(maxHits, hits);
            }

            return maxHits >= 4;
        }

        private bool IsColStrike()
        {
            int maxHits = 0;

            for (var col = 0; col <= 6; col++)
            {
                maxHits = 0;

                int hits = 0;
                int row = 5;
                while (row >= 0)
                {
                    if (Board[row, col] == _currentPlayer)
                    {
                        hits++;
                    }
                    else
                    {
                        maxHits = Math.Max(maxHits, hits);
                        hits = 0;
                    }

                    row--;  //move to the next row
                }

                maxHits = Math.Max(maxHits, hits);
            }

            return maxHits >= 4;
        }

        private bool IsDiagonalStrike()
        {
            int maxHits = 0;

            for (int col = 0; col <= 6; col++)
            {
                for (int row = 0; row <= 5; row++)
                {
                    if (Board[row, col] == _currentPlayer)
                    {
                        int hits = 0;

                        do
                        {   
                            hits++;

                            row++;
                            col++;
                        }
                        while(row <= 5 && row <= 6 &&
                            Board[row, col] == _currentPlayer);

                        maxHits = Math.Max(maxHits, hits);
                    }
                }
            }

            return maxHits >= 4;
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
