using Math=System.Math;

namespace Connect4Library
{
    public class RowCheckup : Checkup
    {
        public RowCheckup(Board board) : base(board) {}

        protected override int GetMaxHitsCount(int value)
        {
            int maxHits = 0;

            for (var row = 0; row <= Board.IndexMaxRows; row++)
            {
                int hits = 0;

                int col = 0;
                while(col <= Board.IndexMaxCols &&
                      this.board[row, col] == value)
                {
                    hits++;

                    col++; // move to the next column
                }

                maxHits = Math.Max(maxHits, hits);
            }

            return maxHits;
        }
    }
}