using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
{
    public class Frames
    {
        private List<Frame> _frames = new List<Frame>();

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
    }
}
