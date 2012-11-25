using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Domain.ServiceProvider
{
    public class Player
    {
        private Frames _frames = new Frames(FrameCountRule.GetCount());

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
