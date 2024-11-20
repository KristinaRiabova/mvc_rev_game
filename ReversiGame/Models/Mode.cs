using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Models
{
    
    internal class Mode
    {
        public string Name { get; }
        public string Header { get; }
        public Mode() 
        {
            Name = "PvP";
            Header = "Reversi Game - Simple View.";
        }
        public Mode(string modeName)
        {
            Name = modeName;
            Header = "Reversi Game - ";
            switch (modeName)
            {
                case "PvE":
                    Header += "Interactive CLI View";
                    break;
                case "PvP":
                    Header += "Simple View";
                    break;
            }

        }
    }
}
