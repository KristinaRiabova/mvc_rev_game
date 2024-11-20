namespace ReversiGame.Models;

public class Move
{
    public int Row { get; }
    public int Col { get; }
    public char PlayerSymbol { get; }

    public Move(int row, int col, char playerSymbol)
    {
        Row = row;
        Col = col;
        PlayerSymbol = playerSymbol;
    }
    // Constructor creating an object with coordinates as a string
    public Move(string coords, char playerSymbol)
    {
        Col = coords[0] - 'A';
        Row = coords[1] - '1';
        PlayerSymbol = playerSymbol;
    }
}