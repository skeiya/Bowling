using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
{
    public class Frame
    {
        private int _frameIndex;
        private List<Roll> _rolls = new List<Roll>();

        public Frame(int index)
        {
            _frameIndex = index;
        }

        public void Append(Roll roll)
        {
            _rolls.Add(roll);
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
