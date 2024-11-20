using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReversiGame.Models;

namespace ReversiGame.Views
{
    public interface IView
    {
        void Display(ViewModel viewModel);
        string GetPlayerInput();
        bool IsInputCancellation();
        
    }
}
