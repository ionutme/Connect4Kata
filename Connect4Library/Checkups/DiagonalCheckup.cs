using Math=System.Math;

namespace Connect4Library
{
    public class DiagonalCheckup : Checkup
    {
        public DiagonalCheckup(Board board) : base(board) {}

        protected override int GetMaxHitsCount(int value)
        {
            int maxHits = 0;

            for (int col = 0; col <= Board.IndexMaxCols; col++)
            {
                for (int row = 0; row <= Board.IndexMaxRows; row++)
                {
                    if (IsHit(row, col, value))
                    {
                        int hits = GetDiagonalHitsCount(value, row, col);

                        maxHits = Math.Max(maxHits, hits);
                    }
                }
            }

            return maxHits;
        }

        private int GetDiagonalHitsCount(int value, int row, int col)
        {
            int maxHits = 1;

            int hits = 1;
            int nextRow = row + 1;
            int nextCol = col + 1;

            while (nextRow <= Board.IndexMaxRows &&
                   nextCol <= Board.IndexMaxCols)
            {
                if (IsHit(row, col, value))
                {
                    hits++;
                }
                else
                {
                    maxHits = Math.Max(maxHits, hits);
                    hits = 0;
                }

                nextRow++;
                nextCol++;
            }

            return Math.Max(maxHits, hits);
        }
    }
}