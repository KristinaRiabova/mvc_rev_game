using ReversiGame.Controllers;
using ReversiGame.Views;

namespace ReversiGame;

public class Program
{
    static void Main(string[] args)
    {
        IView view = new SimpleView();
        IGameController gameController = new GameController(view);
        MainView mainView = new MainView();
        bool cont = true;
        while (cont)
        {
            mainView.Display();
            string? input = mainView.GetPlayerInput();
            if (input == null) continue;
            switch (input)
            {
                case "PvP":
                    view = new SimpleView();
                    gameController = new GameController(view);
                    gameController.StartGame();
                    break;
                case "PvE":
                    view = new EnhancedView();
                    gameController = new BotGameController(view);
                    gameController.StartGame();
                    break;
                case "statistic":
                    mainView.ViewStatistic();
                    break;
                case "quit":
                    cont = false;
                    break;
            }
            
        }
        
    }
}