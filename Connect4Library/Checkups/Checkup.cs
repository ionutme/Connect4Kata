namespace Connect4Library
{
    public abstract class Checkup
    {
        public const int WinningCheckCount = 4;
        protected readonly Board board;

        protected Checkup(Board board)
        {
            this.board = board;
        }

        public bool Check(int value)
        {
            var maxHitCount = GetMaxHitsCount(value);
            if (maxHitCount >= WinningCheckCount)
                return true;

            return false;
        }

        protected abstract int GetMaxHitsCount(int value);
    }
}