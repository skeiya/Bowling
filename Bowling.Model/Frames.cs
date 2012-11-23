using System.Collections.Generic;

namespace Bowling.Domain.Model
{
    public class  Frames
    {
        private readonly List<Frame> _frames = new List<Frame>();

        public Frames(int maxFrameCount)
        {
            for (int i = 0; i < maxFrameCount; i++)
            {
                _frames.Add(new Frame(i));
            }
        }

        public IEnumerator<Frame> GetEnumerator()
        {
            foreach (Frame f in _frames)
            {
                yield return f;
            }
        }

        public IEnumerable<int> GetPins()
        {
            foreach (Frame f in _frames)
            {
                foreach (int pin in f.GetPins())
                {
                    yield return pin;
                }
            }
        }

        public Frame this[int i]
        {
            get { return _frames[i]; }
        }

        public static Frames Replace(Frames old, Frame from, Frame to)
        {
            Frames frames = new Frames(old._frames.Count);
            for (int i = 0; i < old._frames.Count; i++)
            {
                if (old._frames[i] == from)
                {
                    frames._frames[i] = to;
                }
                else
                {
                    frames._frames[i] = old._frames[i];
                }
            }
            return frames;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            
            Frames target = (Frames)obj;
            if (this._frames.Count != target._frames.Count) return false;
            for (int i = 0; i < this._frames.Count; i++)
            {
                if (!this._frames[i].Equals(target._frames[i])) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach (Frame f in _frames)
            {
                hash += f.GetHashCode();
            }
            return hash;
        }
    }
}
