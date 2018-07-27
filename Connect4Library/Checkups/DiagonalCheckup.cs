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
            int hits = 1;

            int nextRow = row + 1;
            int nextCol = col + 1;

            while (IsHit(row, col, value) &&
                   nextRow <= Board.IndexMaxRows &&
                   nextCol <= Board.IndexMaxCols)
            {
                hits++;

                nextRow++;
                nextCol++;
            }

            return hits;
        }
    }
}