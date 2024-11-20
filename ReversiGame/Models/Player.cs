namespace ReversiGame.Models;

public class Player
{
    public char Symbol { get; }
    public string Name { get; }

    public Player(char symbol, string name)
    {
        Symbol = symbol;
        Name = name;
    }

}