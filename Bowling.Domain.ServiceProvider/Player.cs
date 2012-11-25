using System;
using System.Collections.Generic;
using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Domain.ServiceProvider
{
    public class Player
    {
        private Frames _frames = new Frames(FrameCountRule.GetCount());
        private IUserInterface _ui;
        private IWriteFile _writeFile;
        private IReadFile _readFile;

        /// <summary>
        /// For test only
        /// </summary>
        public Player()
        {
        }

        public Player(IUserInterface ui, IWriteFile writeFile, IReadFile readFile)
        {
            _ui = ui;
            _writeFile = writeFile;
            _readFile = readFile;
        }

        public void Roll(int p)
        {
            _frames = RollService.Roll(_frames, p);
        }

        public Score CalcScore()
        {
            return ScoreService.Calc(_frames);
        }

        public bool IsEnd()
        {
            return RollService.IsEnd(_frames);
        }

        public void Load(string path)
        {
            _frames = LoadService.Load(new Frames(FrameCountRule.GetCount()), path, _readFile);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return this._frames.Equals(((Player)obj)._frames);
        }

        public override int GetHashCode()
        {
            return _frames.GetHashCode();
        }

        internal Frames GetFrames()
        {
            return _frames;
        }

        internal void SetFrames(Frames frames)
        {
            _frames = frames;
        }
    }
}
