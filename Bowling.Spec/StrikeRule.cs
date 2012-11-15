﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;

namespace Bowling.Spec
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
    }
}