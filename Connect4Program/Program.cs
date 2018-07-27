using System;
using Connect4Library;
using Connect4Library.GameBoard;

namespace Connect4Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            /*==========================
               0   1   2   3   4   5   6
            0                           
            
            1                           

            2  1                        

            3  2   1                    

            4  1   2   1                 

            5  2   1   2   1           2   

               0   1   2   3   4   5   6    
            ==========================*/

            game.play(3);
            game.play(2);
            game.play(2);
            game.play(6);
            game.play(1);
            game.play(1);
            game.play(1);
            game.play(0);
            game.play(0);
            game.play(0);
            game.play(0); // Diag STRIKE
            game.play(5); // Game Finished

            game.Board.Print(Console.Write);
        }
    }
}
