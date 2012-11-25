using System.Collections.Generic;
using Bowling.Domain.Model;
using Bowling.Domain.ServiceProvider;
using Bowling.Domain.Spec;

namespace Bowling.ServiceProvider
{
    class CallBack : IUserInterfaceCallBack
    {
        private Game _game;
        private IWriteFile _writeFile;
        private IReadFile _readFile;

        public CallBack(Game game, IWriteFile writeFile, IReadFile readFile)
        {
            this._game = game;
            this._writeFile = writeFile;
            this._readFile = readFile;
        }

        public bool IsEnd()
        {
            return _game.IsEnd();
        }

        public void Save(string p)
        {
            SaveService.Save(_game.GetPlayer().GetFrames(), p, _writeFile);
        }

        public void Load(string p)
        {
            _game.GetPlayer().SetFrames(LoadService.Load(p, _readFile));
        }

        public void Roll(int p)
        {
            _game.GetPlayer().SetFrames(RollService.Roll(_game.GetPlayer().GetFrames(), p));
        }

        public IEnumerable<Score> GetScores()
        {
            Frames frames = _game.GetPlayer().GetFrames();
            int index = 0;
            foreach (Frame f in frames)
            {
                if (!FullFrameRule.IsFull(f)) break;
                yield return ScoreService.CalcAt(frames, index++);
            }
        }

        public IEnumerable<int> GetFrameNumbers()
        {
            for (int i = 0; i < FrameCountRule.GetCount(); i++)
            {
                yield return i + 1;
            }
        }

        public IEnumerable<Frame> GetFrames()
        {
            foreach (Frame f in _game.GetPlayer().GetFrames())
            {
                yield return f;
            }
        }
    }
}
