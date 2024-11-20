using ReversiGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Views
{
    public class SimpleView : IView
    {
        public void Display(ViewModel viewModel)
        {
            Console.Clear();
            Console.WriteLine("Reversi Game - Simple View");
            Console.WriteLine("----------------------------\n");
            Console.WriteLine($"Player's {viewModel.currentPlayer} turn\n");

            Console.WriteLine("  A B C D E F G H");
            char[,] grid = viewModel.board;

            for (int i = 0; i < viewModel.gridSize; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < viewModel.gridSize; j++)
                {
                    Console.Write($"{grid[i, j]} ");
                }
                Console.WriteLine();
            }

            switch (viewModel.message)
            {
                case ReversiMessage.PlayerTurn:
                    Console.WriteLine("Available commands:");
                    Console.WriteLine(" - move [coordinate] (e.g., D4)");
                    Console.WriteLine(" - hint");
                    Console.WriteLine(" - undo");
                    Console.WriteLine(" - skip");
                    Console.WriteLine(" - quit");

                    Console.WriteLine($"Player {viewModel.currentPlayer}, enter your command: ");
                    
                    break;
                case ReversiMessage.InvalidInput:
                    Console.WriteLine("Invalid input, please try again.");
                    Console.ReadKey();
                    break;
                case ReversiMessage.PlayerWins:
                    Console.WriteLine($"Player {viewModel.currentPlayer} wins!");
                    Console.WriteLine($"Scope game:  {viewModel.scope}");
                    Console.ReadKey();
                    break;
                case ReversiMessage.Draw:
                    Console.WriteLine("It's a draw!");
                    Console.ReadKey();
                    break;
            }
        }
        public string GetPlayerInput()
        {
            string line = Console.ReadLine();
            return line;
        }



        public bool IsInputCancellation()
        {
            // There is no implementation of this method in this class
            return false;
        }


    }
}
