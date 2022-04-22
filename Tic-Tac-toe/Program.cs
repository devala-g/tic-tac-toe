using System;

namespace Tic_Tac_toe
{
    class Program
    {
        static void Main()
        {
            var b = new Board(); //initialize the board

            //print welcome message:
            Console.WriteLine("Welcome to Tic-tac-toe!\n");
            Console.WriteLine("Player 1 is o");
            Console.WriteLine("Player 2 is x\n");
            Console.WriteLine("Enter Player 1's name: ");
            b.names['o'] = Console.ReadLine();
            Console.WriteLine("Enter Player 2's name: ");
            b.names['x'] = Console.ReadLine();
            Console.WriteLine(); //add a new line

            for (int i = 0; i < 9; i++) //game will never last more than 9 rounds. 
            {
                b.PrintBoard();

                if (b.quit)
                    break;
                if (i == 8) //if someone won on the last round, this won't be reached:
                    Console.WriteLine("It's a tie!\n");

                b.p1Turn = !b.p1Turn;
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
