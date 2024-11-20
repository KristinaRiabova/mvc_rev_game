using System.Numerics;

namespace ReversiGame.Models;

public class Board
{
    public const int Size = 8;
    private readonly char[,] grid;
    private readonly char[,] backupGrid;

    public Board()
    {
        grid = new char[Size, Size];
        backupGrid = new char[Size, Size];
        InitializeBoard();
    }
    public Board(Board b)
    {
        grid = new char[Size, Size];
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                grid[i, j] = b.GetGrid()[i,j];
            }
        }

    }

    private void InitializeBoard()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                grid[i, j] = '.';
            }
        }
        grid[3, 3] = 'O';
        grid[3, 4] = 'X';
        grid[4, 3] = 'X';
        grid[4, 4] = 'O';
        SaveBackupGrid();
    }

    // Save the board for the ability to undo a move
    public void SaveBackupGrid()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                backupGrid[i, j] = grid[i, j];
            }
        }
    }

    // Undo move
    public void RestoreGrid()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
               grid[i, j] = backupGrid[i, j];
            }
        }
    }
    public bool IsValidMove(int row, int col, char player)
    {
        bool condition = row >= 0 && row < Size && col >= 0 && col < Size && grid[row, col] == '.';
        // Logic to validate moves (placeholder)
        if (!condition)
        {
            return false;
        }
        // Checking for the presence of an opponent's token
        char opponent = player == 'X' ? 'O' : 'X';
        // if there is no enemy in the adjacent cells
        return FindOpponent(row, col, player, opponent);

    }

    public void MakeMove(int row, int col, char player)
    {
        grid[row, col] = player;
        // Logic to flip opponent pieces

        // Checking the opponent's chips
        CheckingOpponentChips(row,col,player);
    }

    // Method for determining the possibility of moving to a specified cell
    private bool FindOpponent(int row, int col, char player, char opponent)
    {
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (FindOpponentByDirection(row, col, i, j, player, opponent))
                {
                    return true;
                }
            }
        }
        return false;
    }
    private bool FindOpponentByDirection(int row, int col, int dr, int dc, char player, char opponent)
    {
        int r = row + dr;
        int c = col + dc;

        // Checking for out-of-bounds
        if (r < 0 || r >= Size || c < 0 || c >= Size)
        {
            return false;
        }

        // We check if our piece is in the neighboring cell,
        // then the direction for the move is not suitable
        if (grid[r, c] == player) return false;

        // We go to the end of the line of opponent's chips,
        // then we check, if there is our chip, then we say that the move is possible
        while (r>=0 && r<Size && c>=0 && c<Size && grid[r,c] == opponent)
        {
            r += dr;
            c += dc;
        }
        if (r<0 || r>=Size || c<0 || c>=Size) return false;
        if (grid[r, c] == player) return true;

        return false;
    }
    // Replacing players' chips with your own chips
    private void CheckingOpponentChips(int col, int row, char player)
    {
        char opponent = player == 'X' ? 'O' : 'X';
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                // We check if a replacement is possible in the string, then we call the replacement method
                if (FindOpponentByDirection(col, row, i, j, player, opponent))
                {
                    CheckingOpponentChipsByDirection(col,row,i,j,player,opponent);
                }
            }
        }
    }
    // Replacing players' chips with your own chips in the specified direction
    private void CheckingOpponentChipsByDirection(int row, int col, int dr, int dc, char player, char opponent)
    {
        int r = row + dr;
        int c = col + dc;
        while (grid[r, c] == opponent)
        {
            grid[r, c] = player;
            r += dr;
            c += dc;
        }
    }

    // Method for calculating the game score for one of the players
    public int GameScore(char player)
    {
        int s = 0;
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (grid[i, j] == player)
                {
                    s++;
                }
            }
        }
        return s;
    }
    public char[,] GetGrid() => grid;

    public char[,] GetGridWithHint(char player)
    {
        char[,] gridWithHint= new char[Size, Size];

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (IsValidMove(i,j,player))
                {
                    gridWithHint[i, j] = '*';
                }
                else
                {
                    gridWithHint[i, j] = grid[i, j];
                }
            }
        }
        return gridWithHint;
    }
    public bool HasMoveForPlayer(char player)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (IsValidMove(i, j, player))
                {
                    return true;
                }
            }
        }
        return false;
    }


}