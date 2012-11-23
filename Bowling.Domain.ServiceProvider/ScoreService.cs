using System.Collections.Generic;
using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Domain.ServiceProvider
{
    public class ScoreService
    {
        public static Score Calc(Frames frames)
        {
            return CalcAt(frames, FrameCountRule.GetCount() - 1);
        }

        private static int CalcBonus(Frames frames, int index)
        {
            int sum = 0;
            for (int i = 0; i < index + 1; i++)
            {
                sum += CalcBonusFrame(frames[i], frames);
            }
            return sum;
        }

        private static int CalcBonusFrame(Frame f, Frames frames)
        {
            int bonus = 0;
            int bonusCount = GetBonusCount(f);

            foreach (int pins in GetPinsAfterFrame(f, frames))
            {
                if (bonusCount == 0) return bonus;
                bonus += pins;
                bonusCount--;
            }
            return bonus;
        }

        private static int GetBonusCount(Frame f)
        {
            if (SpareRule.IsSpare(f)) return 1;
            if (StrikeRule.IsStrike(f)) return 2;
            return 0;
        }

        private static IEnumerable<int> GetPinsAfterFrame(Frame target, Frames frames)
        {
            bool found = false;
            foreach (Frame f in frames)
            {
                if (target == f)
                {
                    found = true;
                    continue;
                }
                if (!found) continue;
                foreach (int pin in f.GetPins()) yield return pin;
            }
        }

        private static int CalcBase(Frames frames, int index)
        {
            int sum = 0;
            for (int i = 0; i < index + 1; i++)
            {
                sum += CalcFrame(frames[i]);
            }
            return sum;
        }

        private static int CalcFrame(Frame f)
        {
            int sum = 0;
            foreach (int pin in f.GetPins()) sum += pin;
            return sum;
        }

        public static Score CalcAt(Frames frames, int index)
        {
            return new Score(CalcBase(frames, index) + CalcBonus(frames, index));
        }
    }
}
