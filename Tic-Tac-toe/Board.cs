using System;
using System.Collections.Generic;

namespace Tic_Tac_toe
{
    public class Board
    {
        //Variables
        private char[,] slots = new char[3,3] {
            { '_', '_', '_' },
            { '_', '_', '_' },
            { '_', '_', '_' }
        }; //use a 2d array for the slots on the board. 

        public IDictionary<char, string> names = new Dictionary<char, string>();

        private IDictionary<char, bool> won = new Dictionary<char, bool>() {
            { 'o', false },
            { 'x', false} }; //holds the symbol and won value.

        public bool p1Turn = true;

        public bool quit = false;


        //Functions
        public Board(){} //constructor

        private bool CheckWin(char sym)
        {
            for (int i = 0; i < 3; i++) 
            {
                if (slots[i,0] == sym && slots[i, 1] == sym && slots[i, 2] == sym) //check all the rows
                    won[sym] = true;
                if (slots[0, i] == sym && slots[1, i] == sym && slots[2, i] == sym) //check all the colums
                    won[sym] = true;
            }
            if ( (slots[0, 0] == sym && slots[1, 1] == sym && slots[2, 2] == sym)
                || (slots[0, 2] == sym && slots[1, 1] == sym && slots[2, 0] == sym)) //check the diagonals
                won[sym] = true;
            return won[sym];
        }
        
        public void PrintBoard()
        {
            Console.WriteLine("----------\n");

            char sym;
            if (p1Turn)
                sym = 'o';
            else
                sym = 'x';

            Console.WriteLine($"{names[sym]}'s turn ({sym}):\n");

            Console.WriteLine("\tA\tB\tC");
            for (int i = 0; i < 3; i++)
                Console.WriteLine($"{i + 1}\t{slots[i, 0]}\t{slots[i, 1]}\t{slots[i, 2]}"); //layout the current moves

            bool incorrectEntry = false;
            do //using this loop so it will execute at least once. 
            {
                Console.WriteLine("Enter your move (e.g. enter b2 for the middle of the board and q to quit): ");

                string input = Console.ReadLine().ToLower();

                if (input == "q")
                    quit = true;
                else
                {
                    if (input[0] < 'a' || input[0] > 'c' || input[1] < '1' || input[1] > '3' //if entry is out of range
                        || slots[input[1] - '1', input[0] - 'a'] != '_') // or if entry is already taken
                    {
                        incorrectEntry = true;
                        Console.WriteLine("Incorrect entry. Try again\n");
                    }
                    else
                    {
                        incorrectEntry = false; 
                        int row = input[1] - '1'; //subtracting to convert to appropriate index
                        int col = input[0] - 'a';

                        slots[row, col] = sym;
                        if (CheckWin(sym))
                        {
                            Console.WriteLine($"\n{names[sym]} WON!!! Congratulations");
                            quit = true;
                        }
                    }
                }
            } while (incorrectEntry); // will break out if a move is made
        }
    }
}
