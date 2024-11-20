using ReversiGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Views
{
    public class EnhancedView : IView
    {
        public void Display(ViewModel viewModel)
        {
            Console.Clear();
            Console.WriteLine("Reversi - Interactive CLI View");
            Console.WriteLine("----------------------------\n");
            Console.WriteLine($"Player's {viewModel.currentPlayer} (You) vs Bot (O)\n");

            Console.WriteLine("   | A | B | C | D | E | F | G | H ");
            Console.WriteLine("-----------------------------------");

            char[,] grid = viewModel.board;

            for (int i = 0; i < viewModel.gridSize; i++)
            {
                Console.Write(" {0} ",i+1);
                for (int j = 0; j < viewModel.gridSize; j++)
                {
                    Console.Write("| {0} ", grid[i, j]);
                }
                
                Console.WriteLine("\n-----------------------------------");
            }

            switch (viewModel.message)
            {
                case ReversiMessage.PlayerTurn:

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
            var confirmed = false;
            var timer = new System.Timers.Timer(20000);
            timer.Elapsed += (sender, e) =>
            {
                if (!confirmed)
                {
                    // відповідні дії
                    timer.Stop();
                }
            };
            timer.Start();
            while (timer.Enabled)
            {
                if (System.Console.KeyAvailable)
                {
                    var input = System.Console.ReadLine();
                    if (input != null)
                    {
                        //відповідна логіка тут
                        confirmed = true;
                        timer.Stop();
                        return input;
                    }
                }
            }
            return "";
        }

        
        public bool IsInputCancellation()
        {
            var confirmed = false;
            var timer = new System.Timers.Timer(3000);
            timer.Elapsed += (sender, e) =>
            {
                if (!confirmed)
                {
                    // відповідні дії
                    timer.Stop();
                }
            };
            timer.Start();
            while (timer.Enabled)
            {
                if (System.Console.KeyAvailable)
                {
                    var input = System.Console.ReadLine();
                    if (input != null)
                    {
                        //відповідна логіка тут
                        confirmed = true;
                        timer.Stop();
                        if (input == "undo")
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
