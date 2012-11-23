using Bowling.Domain.Model;

namespace Bowling.Domain.Spec
{
    public class StrikeRule
    {
        public static bool IsStrike(Frame f)
        {
            return IsCountMatch(f) && IsPinMatch(f);
        }

        private static bool IsCountMatch(Frame f)
        {
            return f.GetRollCount() == 1;
        }

        private static bool IsPinMatch(Frame f)
        {
            return SumPin(f) == PinNumberRule.GetMax();
        }

        private static int SumPin(Frame f)
        {
            int sum = 0;
            foreach (int pin in f.GetPins()) sum += pin;
            return sum;
        }

        public static bool IsStrike(Roll roll)
        {
            return roll.GetPin() == PinNumberRule.GetMax();
        }
    }
}
