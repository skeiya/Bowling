using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
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
    }
}
