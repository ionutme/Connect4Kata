using Math=System.Math;

namespace Connect4Library
{
    public class ColumnCheckup : Checkup
    {
        public ColumnCheckup(Board board) : base(board) {}

        protected override int GetMaxHitsCount(int value)
        {
            int maxHits = 0;

            for (var col = 0; col <= Board.IndexMaxCols; col++)
            {
                int hits = GetColumnMaxHitsCount(value, col);

                maxHits = Math.Max(maxHits, hits);
            }

            return maxHits;
        }

        private int GetColumnMaxHitsCount(int value, int col)
        {
            int maxHits = 0;

            int hits = 0;
            int row = Board.IndexMaxRows;
            while (row >= 0)
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

                row--;  //move to the next row
            }

            return Math.Max(maxHits, hits);
        }
    }
}