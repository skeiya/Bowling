using Bowling.Presentation;
using Infrastructure;

namespace Bowling.Execution
{
    class Program
    {
        static void Main(string[] args)
        {
            Session app = new Session(new UserInterface(), new FileSystem());
            app.Start();
        }
    }
}
