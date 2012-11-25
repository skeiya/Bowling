using System;
using System.Text;
using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Presentation
{
    public class RollFormatter
    {
        public static string GetRollsOfFrame(Frame f)
        {
            if (FrameCountRule.IsLastFrame(f))
            {
                return GetRollsOfLastFrame(f);
            }

            if (StrikeRule.IsStrike(f))
            {
                return "   X";
            }
            if (SpareRule.IsSpare(f))
            {
                return string.Format("{0,2}", f[0].GetPin()) + " /";
            }
            StringBuilder buf = new StringBuilder();
            foreach (int pin in f.GetPins())
            {
                buf.AppendFormat("{0,2}", pin);
            }
            return buf.ToString();
        }

        private static string GetRollsOfLastFrame(Frame f)
        {
            if (f.GetRollCount() == 0) return "    ";
            if (f.GetRollCount() == 1)
            {
                if (StrikeRule.IsStrike(f[0])) return " X  ";
                return string.Format(" {0}  ", f[0].GetPin());
            }
            if (f.GetRollCount() == 2)
            {
                if (StrikeRule.IsStrike(f[0]))
                {
                    if (StrikeRule.IsStrike(f[1])) return " XX ";
                    return string.Format(" X{0} ", f[1].GetPin());
                }
                if (SpareRule.IsSpare(f)) return string.Format(" {0}/ ", f[0].GetPin());
                return string.Format(" {0} {1}", f[0].GetPin(), f[1].GetPin());
            }
            if (f.GetRollCount() == 3)
            {
                if (StrikeRule.IsStrike(f[0]))
                {
                    if (StrikeRule.IsStrike(f[1]))
                    {
                        if (StrikeRule.IsStrike(f[2])) return " XXX";
                        return string.Format(" XX{0}", f[2].GetPin());
                    }
                    if (SpareRule.IsSpare(f[1], f[2])) return string.Format(" X{0}/", f[1].GetPin());
                    return string.Format(" X{0}{1}", f[1].GetPin(), f[2].GetPin());
                }
                if (StrikeRule.IsStrike(f[2])) return string.Format(" {0}/X", f[0].GetPin());
                return string.Format(" {0}/{1}", f[0].GetPin(), f[2].GetPin());
            }
            throw new Exception();
        }

    }
}
