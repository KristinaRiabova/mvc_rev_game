using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Models
{
    public interface IBot
    {
        string Name { get; }
        string ChooseMove();
    }
}
