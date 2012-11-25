using Bowling.Domain.Model;
namespace Bowling.Domain.ServiceProvider
{
    public class CommandRoll : ICommand
    {
        private Player _player;
        private int _pin;

        public CommandRoll(Player player, int pin)
        {
            _player = player;
            _pin = pin;
        }

        public void Exec()
        {
            Frames frames = RollService.Roll(_player.GetFrames(), _pin);
            _player.SetFrames(frames);
            ScoreDrawer.Draw(frames);
        }
    }
}
