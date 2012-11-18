using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Application;

namespace Bowling.Presentation
{
    public class CommandLoad : ICommand
    {
        private Game _game;
        private string _path;

        public CommandLoad(Game game, string p)
        {
            this._game = game;
            this._path = p;
        }

        public void Exec()
        {
            _game.Load(_path);
        }
    }
}
