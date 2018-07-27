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
                var hits = 0;

                int row = Board.IndexMaxRows;
                while(row >= 0 &&
                      this.board[row, col] == value)
                {
                    hits++;

                    row--; //move to the next row
                }

                maxHits = Math.Max(maxHits, hits);
            }

            return maxHits;
        }
    }
}