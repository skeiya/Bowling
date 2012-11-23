using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Domain.ServiceProvider;
using Bowling.Presentation;
using Infrastructure;

namespace Bowling.DependencyInjector
{
    public class Injector
    {
        public static IUserInterface CreateUserInterface()
        {
            return new UserInterface();
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
