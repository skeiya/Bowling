﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Domain.ServiceProvider;
using Bowling.Infrastructure;

namespace Bowling.DependencyInjector
{
    public class Injector
    {
        public static IMyConsole CreateUserInterface()
        {
            return new MyConsole();
        }

        public static IWriteFile CreateWriteFile()
        {
            return new WriteFile();
        }

        public static IReadFile CreateReadFile()
        {
            return new ReadFile();
        }
    }
}
