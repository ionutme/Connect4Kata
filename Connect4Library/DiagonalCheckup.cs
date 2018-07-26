using Math=System.Math;

namespace Connect4Library
{
    public class DiagonalCheckup : Checkup
    {
        public DiagonalCheckup(Board board) : base(board) {}

        protected override int GetMaxHitsCount(int value)
        {
            int maxHits = 0;

            int hits;
            for (int col = 0; col <= Board.IndexMaxCols; col++)
            {
                for (int row = 0; row <= Board.IndexMaxRows; row++)
                {
                    hits = 0;

                    if (this.board[row, col] == value)
                    {
                        hits++;

                        int nextRow = row + 1;
                        int nextCol = col + 1;
                        while (nextRow <= Board.IndexMaxRows &&
                               nextCol <= Board.IndexMaxCols &&
                               this.board[nextRow, nextCol] == value)
                        {
                            hits++;

                            nextRow++;
                            nextCol++;
                        }

                        maxHits = Math.Max(maxHits, hits);
                    }
                }
            }

            return maxHits;
        }
    }
}