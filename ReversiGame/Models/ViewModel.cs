using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Models
{
    public class ViewModel
    {
        public char[,] board { get; set; }
        public char currentPlayer { get; set; }
        public int gridSize { get; set; }
        public int scope { get; set; }
        public ReversiMessage message { get; set; }
    }
    public enum ReversiMessage
    {
        PlayerTurn,
        InvalidInput,
        PlayerWins,
        Draw
    }
    
}
