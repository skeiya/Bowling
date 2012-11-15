using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;
using Bowling.Spec;

namespace Bowling.Application
{
    class RemainCalculator
    {
        class RemainCalculatorCore
        {
            private int _remain = PinNumberRule.GetMax();
            private int _prev = PinNumberRule.GetMin();
            private bool _first = true;

            public void Apply(int pin)
            {
                if (IsClean(pin))
                {
                    CleanState();
                    return;
                }
                UpdateState(pin);
            }

            private bool IsClean(int pin)
            {
                if (!_first) return true;
                return _prev + pin == PinNumberRule.GetMax();
            }

            private void CleanState()
            {
                _remain = PinNumberRule.GetMax();
                _prev = PinNumberRule.GetMin();
                _first = true;
            }

            private void UpdateState(int pin)
            {
                _remain -= pin;
                _prev = pin;
                _first = false;
            }

            internal int GetRemain()
            {
                return _remain;
            }
        }

        internal static int Calc(Frames frames)
        {
            RemainCalculatorCore core = new RemainCalculatorCore();
            foreach (int pin in frames.GetPins())
            {
                core.Apply(pin);
            }
            return core.GetRemain();
        }
    }
}
