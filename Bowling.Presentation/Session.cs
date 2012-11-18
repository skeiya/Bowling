using System;
using Bowling.Application;

namespace Bowling.Presentation
{
    public class Session
    {
        private IUserInterface _ui;

        public Session(IUserInterface ui)
        {
            _ui = ui;
        }

        public void Start()
        {
            Game game = new Game();
            while (!game.IsEnd())
            {
                ICommand c = CommandFactory.CraeteFromUserInput(_ui, game);
                c.Exec();
            }
            Console.ReadKey();
        }
    }
}
