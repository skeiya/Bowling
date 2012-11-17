using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
{
    public class Frame
    {
        private readonly int _frameIndex;
        private readonly List<Roll> _rolls = new List<Roll>();

        public Frame(int index)
        {
            _frameIndex = index;
        }

        public Frame(int index, List<Roll> rolls)
        {
            this._frameIndex = index;
            foreach (Roll r in rolls) this._rolls.Add((Roll)r.Clone());
        }

        public static Frame Append(Frame old, Roll roll)
        {
            List<Roll> tmp = new List<Roll>(old._rolls);
            tmp.Add(roll);
            return new Frame(old.GetFrameIndex(), tmp);
        }

        public int GetRollCount()
        {
            return _rolls.Count;
        }

        public IEnumerable<int> GetPins()
        {
            foreach (Roll r in _rolls)
            {
                yield return r.GetPin();
            }
        }

        public int GetFrameIndex()
        {
            return _frameIndex;
        }

        public Roll this[int i]
        {
            get { return _rolls[i]; }
        }

    }
}
