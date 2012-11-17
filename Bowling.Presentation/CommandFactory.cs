using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application;

namespace Bowling.Presentation
{
    class CommandFactory
    {
        private static int GetPinFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Please input integer (from 0 to 10).");
                try
                {
                    string inputStr = Console.ReadLine();
                    return int.Parse(inputStr);
                }
                catch (Exception)
                {
                }
            }
        }

        internal static ICommand CraeteFromUserInput(Game game)
        {
            return new CommandRoll(game, GetPinFromUserInput());
        }
    }

}
