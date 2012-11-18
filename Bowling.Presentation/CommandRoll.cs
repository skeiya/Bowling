using Bowling.Application;

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
