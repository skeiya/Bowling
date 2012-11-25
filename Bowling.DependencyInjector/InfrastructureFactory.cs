using Bowling.Domain.ServiceProvider;
using Bowling.Infrastructure;

namespace Bowling.DependencyInjector
{
    public class InfrastructureFactory
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
