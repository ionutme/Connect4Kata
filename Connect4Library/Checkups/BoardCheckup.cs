using System;
using System.Linq;
using System.Collections.Generic;

namespace Connect4Library
{
    public class BoardCheckup
    {
        private List<Checkup> checkups;

        public BoardCheckup(Board board)
        {
            this.checkups = new List<Checkup>
            {
                new RowCheckup(board),
                new ColumnCheckup(board),
                new DiagonalCheckup(board)
            };
        }

        public bool IsConnect4(int value)
        {
            return this.checkups.Any(x => x.Has4Hits(value));
        }
    }
}