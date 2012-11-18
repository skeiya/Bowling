using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application;
using Bowling.Model;
using Bowling.Spec;

namespace Bowling.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            IUserInterface ui = UserInterface();
            while (!game.IsEnd())
            {
                ICommand c = CommandFactory.CraeteFromUserInput(ui, game);
                c.Exec();
            }
            Console.ReadKey();
        }

        private static IUserInterface UserInterface()
        {
            throw new NotImplementedException();
        }
    }
}
