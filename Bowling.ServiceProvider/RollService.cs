using System;
using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Domain.ServiceProvider
{
    public class RollService
    {
        public static Frames Roll(Frames frames, int p)
        {
            Frame f = GetLastNotFullFrame(frames);
            if (!Acceptable(frames, p)) throw new Exception();
            return Frames.Replace(frames, f, Frame.Append(f, new Roll(p)));
        }

        public static bool Acceptable(Frames frames, int p)
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

        public static bool IsEnd(Frames frames)
        {
            return FullFrameRule.IsFull(frames[FrameCountRule.GetCount() - 1]);
        }
    }
}
