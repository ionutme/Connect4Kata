namespace Connect4Library
{
    public abstract class Checkup
    {
        public const int WinningCheckCount = 4;
        private readonly Board board;

        protected Checkup(Board board)
        {
            this.board= board;
        }

        public bool Has4Hits(int value)
        {
            int maxHitCount = GetMaxHitsCount(value);

            return maxHitCount >= WinningCheckCount;
        }

        protected abstract int GetMaxHitsCount(int value);

        protected bool IsHit(int row, int col, int value)
        {
            return this.board[row, col] == value;
        }
    }
}