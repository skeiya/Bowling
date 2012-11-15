using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;
using Bowling.Spec;

namespace Bowling.Application
{
    class RollService
    {
        internal static void Roll(Frames frames, int p)
        {
            Frame f = GetLastNotFullFrame(frames);
            if (!Acceptable(frames, p)) throw new Exception();
            f.Append(new Roll(p));
        }

        internal static bool Acceptable(Frames frames, int p)
        {
            if (p < 0) return false;
            return GetRemainPins(frames) >= p;
        }

        private static int GetRemainPins(Frames frames)
        {
            return RemainCalculator.Calc(frames);
        }

        private static Frame GetLastNotFullFrame(Frames frames)
        {
            foreach (Frame f in frames)
            {
                if (!FullFrameRule.IsFull(f)) return f;
            }
            throw new Exception();
        }

        internal static bool IsEnd(Frames frames)
        {
            return FullFrameRule.IsFull(frames[FrameCountRule.GetCount() - 1]);
        }
    }
}
