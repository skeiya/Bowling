﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;

namespace Bowling.Spec
{
    public class FrameCountRule
    {
        public static int GetCount()
        {
            return 10;
        }

        public static bool IsLastFrame(Frame f)
        {
            return f.GetFrameIndex() == GetCount() - 1;
        }
    }
}
