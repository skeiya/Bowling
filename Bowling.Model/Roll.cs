﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Model
{
    public class Roll
    {
        private readonly int _pin;

        public Roll(int p)
        {
            this._pin = p;
        }

        public int GetPin()
        {
            return _pin;
        }

        public object Clone()
        {
            return new Roll(_pin);
        }
    }
}
