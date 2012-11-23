
using Bowling.DependencyInjector;
using Bowling.Domain.ServiceProvider;
namespace Bowling.Execution
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(Injector.CreateUserInterface(), Injector.CreateWriteFile(), Injector.CreateReadFile());
            game.Start();
        }
    }
}
