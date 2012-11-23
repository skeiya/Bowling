
using Bowling.Domain.Model;
using Bowling.Domain.Spec;
namespace Bowling.Domain.ServiceProvider
{
    public class CommandLoad : ICommand
    {
        private Game _game;
        private string _path;
        private IReadFile _readFile;

        public CommandLoad(Game game, string p, IReadFile readFile)
        {
            this._game = game;
            this._path = p;
            this._readFile = readFile;
        }

        public void Exec()
        {
            Frames frames = LoadService.Load(new Frames(FrameCountRule.GetCount()), _path, _readFile);
            _game.SetFrames(frames);
            ScoreDrawer.Draw(frames);
        }
    }
}
