using ReversiGame.Models;
using ReversiGame.Services;
using ReversiGame.Views;
using System.Reflection;

namespace ReversiGame.Controllers;

public class GameController : IGameController
{
    private readonly Board board;

    private readonly Player player1;
    private readonly Player player2;
    private Player currentPlayer;
    private Mode mode;
    private bool withHint;
    private bool newGame;
    private readonly IView currentView;
    private ViewModel viewModel;
    public GameController(IView view)
    {
        board = new Board();
        //displayService = new CliDisplayService();
        player1 = new Player('X', "Player 1");
        player2 = new Player('O', "Player 2");
        currentPlayer = player1;
        mode = new Mode("PvP");
        withHint = false;
        newGame = false;
        currentView = view;
        viewModel = new ViewModel();
        viewModel.gridSize = Board.Size;
    }
    public void StartGame()
    {
        while (!newGame)
        {
            

                if (withHint)
                {
                    viewModel.board = board.GetGridWithHint(currentPlayer.Symbol);
                }
                else
                {
                    viewModel.board = board.GetGrid();
                }
                viewModel.currentPlayer = currentPlayer.Symbol;
                viewModel.message = ReversiMessage.PlayerTurn;

                currentView.Display(viewModel);

                withHint = false;
                // Reading the command input
                string cline = currentView.GetPlayerInput();
                CheckAction(cline);
            GameEnded();
        }
    }
    public void CheckAction(string? cline)
    {
        if (cline != null)
        {
            string[] items = cline.Split(' ');
            switch (items[0])
            {
                case "move":
                    if (items.Length > 1)
                    {
                        if (items[1].Length == 2)
                        {
                            // Create a new object move
                            MakeMove(items[1]);
                        }
                    }
                    break;
                case "hint":
                    withHint = true;
                    break;
                case "undo":
                    board.RestoreGrid();
                    SwitchPlayer();
                    break;
                case "skip":
                    SwitchPlayer();
                    break;
                case "quit":
                    newGame = true;
                    break;
            }
        }

    }
    public void MakeMove(string coords)
    {
        // Create a new object move
        Move move = new Move(coords, currentPlayer.Symbol);
        if (board.IsValidMove(move.Row, move.Col, currentPlayer.Symbol))
        {
            board.SaveBackupGrid();
            board.MakeMove(move.Row, move.Col, currentPlayer.Symbol);
            SwitchPlayer();
        }
        else
        {
            Console.WriteLine("Invalid move, try again. Press Enter for continue.");
            Console.ReadKey();
        }
    }
    public void SwitchPlayer()
    {
        currentPlayer = currentPlayer == player1 ? player2 : player1;
    }
    public bool HasWinner()
    {
        return Winner() != null? true: false;
    }
    public bool IsGameEnded()
    {
        if (board.HasMoveForPlayer(player1.Symbol) || board.HasMoveForPlayer(player2.Symbol))
        {
            
            return false;
        }

        return true;
    }
    public char? Winner()
    {
        char? winner = null;
        if (IsGameEnded())
        {
            int resPlayer1 = board.GameScore(player1.Symbol);
            int resPlayer2 = board.GameScore(player2.Symbol);
            if (resPlayer1 != resPlayer2)
            {
                winner = resPlayer1 > resPlayer2 ? player1.Symbol : player2.Symbol;
            }
        }
        
        return winner;
    }
    // The method checks if the game is over, if the game is over,
    // it displays a message and starts a new game.
    public void GameEnded()
    {
        if (IsGameEnded()) { 
            if (HasWinner())
            {
                char winner = (char)Winner();
                viewModel = new ViewModel
                {
                    message = ReversiMessage.PlayerWins,
                    currentPlayer = winner,
                    board = board.GetGrid(),
                    gridSize = Board.Size
                };
                currentView.Display(viewModel);
                newGame = true;
            }
            else
            {
                viewModel = new ViewModel
                {
                    message = ReversiMessage.Draw,
                    board = board.GetGrid(),
                    gridSize = Board.Size
                };
                currentView.Display(viewModel);
                newGame = true;
            }
        }
    }
}