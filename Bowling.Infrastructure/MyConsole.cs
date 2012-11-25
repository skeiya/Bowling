using System;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Infrastructure
{
    public class MyConsole : IMyConsole
    {
        public void WriteLine(string p)
        {
            Console.WriteLine(p);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
