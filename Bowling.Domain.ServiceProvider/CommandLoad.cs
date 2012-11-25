
using Bowling.Domain.Model;
using Bowling.Domain.Spec;
namespace Bowling.Domain.ServiceProvider
{
    public class CommandLoad : ICommand
    {
        private Player _player;
        private string _path;
        private IReadFile _readFile;

        public CommandLoad(Player player, string p, IReadFile readFile)
        {
            this._player = player;
            this._path = p;
            this._readFile = readFile;
        }

        public void Exec()
        {
            Frames frames = LoadService.Load(_path, _readFile);
            _player.SetFrames(frames);
            ScoreDrawer.Draw(frames);
        }
    }
}
