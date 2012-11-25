using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Domain.ServiceProvider
{
    public class Game
    {
        private IMyConsole _userInterface;
        private IWriteFile _writeFile;
        private IReadFile _readFile;

        private Player _player = new Player();

        public Game(IMyConsole userInterface, IWriteFile writeFile, IReadFile readFile)
        {
            this._userInterface = userInterface;
            this._writeFile = writeFile;
            this._readFile = readFile;
        }

        public void Start()
        {
            while (!_player.IsEnd())
            {
                try
                {
                    ICommand c = CommandFactory.CraeteFromUserInput(_userInterface, _readFile, _writeFile, _player);
                    c.Exec();
                    if (c.GetType() == typeof(CommandQuit)) return;
                }
                catch (Exception)
                {
                }
            }
            Console.ReadKey();
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}
