using Bowling.Domain.Model;
namespace Bowling.Domain.ServiceProvider
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
            Frames frames = RollService.Roll(_game.GetFrames(), _pin);
            _game.SetFrames(frames);
            ScoreDrawer.Draw(frames);
        }
    }
}
