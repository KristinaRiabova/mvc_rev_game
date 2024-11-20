using ReversiGame.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Controllers
{
    public interface IGameController
    {
        
        void StartGame();
        void CheckAction(string? cline);
        void MakeMove(string coords);
        void SwitchPlayer();
        bool HasWinner();
        bool IsGameEnded();
        char? Winner();
        void GameEnded();
    }
}
