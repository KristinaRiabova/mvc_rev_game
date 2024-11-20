using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ReversiGame.Views
{
    public class MainView
    {
        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Reversi Game:");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Check mode for game:");
            Console.WriteLine(" - PvP (game for 2 player");
            Console.WriteLine(" - PvE (game with bot)");
            Console.WriteLine(" - statistic");
            Console.WriteLine(" - quit");

        }
        public string? GetPlayerInput()
        {
            string? input = Console.ReadLine();
            return input;
        }

        public void ViewStatistic()
        {
            Console.Clear();
            Console.WriteLine("Statistic game:");
            int c = 0;
            using (StreamReader inputFile = new StreamReader("WriteLines.txt"))
            {

                string? line;

                while ((line = inputFile.ReadLine()) != null)
                {
                    c++;
                    Console.WriteLine(c.ToString()+ ". " + line);
                }
            }
            if (c == 0) Console.WriteLine("Games not found");
            Console.ReadKey();

            
        }
    }
}
