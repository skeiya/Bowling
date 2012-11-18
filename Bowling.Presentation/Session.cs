using System;
using Bowling.Application;

namespace Bowling.Presentation
{
    public class Session
    {
        private IUserInterface _ui;
        private IFileSystem _fileSystem;

        public Session(IUserInterface ui, IFileSystem fileSystem)
        {
            _ui = ui;
            _fileSystem = fileSystem;
        }

        public void Start()
        {
            Game game = new Game(_fileSystem);
            while (!game.IsEnd())
            {
                ICommand c = CommandFactory.CraeteFromUserInput(_ui, game);
                c.Exec();
            }
            Console.ReadKey();
        }
    }
}
