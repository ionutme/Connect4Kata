using System;

namespace Connect4Library.GameBoard
{
    public static class BoardExtensions
    {
        public static void Print(this Board board, Action<string> writeAction)
        {
            for (int row=0; row<=5; row++)
            {
                for (int col=0; col<=6; col++)
                {
                    var cellValue = board[row, col] == null ? "-" : board[row,col].ToString();
                    
                    writeAction($"{cellValue} ");
                }

                writeAction(Environment.NewLine);
            }
        }
    }
}