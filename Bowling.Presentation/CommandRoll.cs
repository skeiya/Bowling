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
    public class CommandRoll : ICommand
    {
        private Game _game;
        private int _pin;

        public CommandRoll(Game game, int pin)
        {
            _game = game;
            _pin = pin;
        }

        public void Exec()
        {
            _game.Roll(_pin);
            ScoreDrawer.Draw(_game);
        }
    }
}
