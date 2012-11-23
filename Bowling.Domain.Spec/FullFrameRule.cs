using Bowling.Domain.Model;

namespace Bowling.Domain.Spec
{
    public class FullFrameRule
    {
        public static bool IsFull(Frame f)
        {
            if (IsLastFrame(f)) return IsFullLastFrame(f);
            if (StrikeRule.IsStrike(f)) return true;
            return IsCountFull(f) || IsPinFull(f);
        }

        private static bool IsLastFrame(Frame f)
        {
            return f.GetFrameIndex() == FrameCountRule.GetCount() - 1;
        }

        private static bool IsFullLastFrame(Frame f)
        {
            if (f.GetRollCount() == 2) return SumPin(f) < PinNumberRule.GetMax();
            return f.GetRollCount() == 3;
        }

        private static bool IsCountFull(Frame f)
        {
            return f.GetRollCount() == 2;
        }

        private static bool IsPinFull(Frame f)
        {
            return SumPin(f) == PinNumberRule.GetMax();
        }

        private static int SumPin(Frame f)
        {
            int sum = 0;
            foreach (int pin in f.GetPins()) sum += pin;
            return sum;
        }
    }
}
