using System;
using Bowling.Application;

namespace Bowling.Presentation
{
    public class Session
    {
        private IUserInterface _ui;
        private IWriteFile _writeFile;
        private IReadFile _readFile;

        public Session(IUserInterface ui, IWriteFile writeFileSystem, IReadFile readFileSystem)
        {
            _ui = ui;
            _writeFile = writeFileSystem;
            _readFile = readFileSystem;
        }

        public void Start()
        {
            Game game = new Game(_writeFile, _readFile);
            while (!game.IsEnd())
            {
                ICommand c = CommandFactory.CraeteFromUserInput(_ui, game);
                c.Exec();
            }
            Console.ReadKey();
        }
    }
}
