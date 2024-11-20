using ReversiGame.Models;
using System;

namespace ReversiGame.Services;

public class CliDisplayService
{
    public void DisplayBoard(Board board, bool withHint, char player)
    {
        Console.Clear();
        Console.WriteLine("Reversi Game - Simple View");
        Console.WriteLine("----------------------------\n");
        Console.WriteLine($"Player's {player} turn\n");

        Console.WriteLine("  A B C D E F G H");
        char[,] grid;
        
        if (withHint)
        {
            grid = board.GetGridWithHint(player);
        }
        else
        {
            grid = board.GetGrid();
        }
        for (int i = 0; i < Board.Size; i++)
        {
            Console.Write($"{i + 1} ");
            for (int j = 0; j < Board.Size; j++)
            {
                Console.Write($"{grid[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    /*
    public Move GetPlayerMove(char playerSymbol)
    {
        Console.WriteLine($"{playerSymbol}'s move (enter in format D4): ");
        string input = Console.ReadLine();
        int col = input[0] - 'A';
        int row = input[1] - '1';
        return new Move(row, col, playerSymbol);
    }
    */

    public string? ReadCommand(char playerSymbol)
    {
        
        Console.WriteLine("Available commands:");
        Console.WriteLine(" - move [coordinate] (e.g., D4)");
        Console.WriteLine(" - hint");
        Console.WriteLine(" - undo");
        Console.WriteLine(" - quit");
        string? input = Console.ReadLine();
        return input;
    }
}