using Bowling.Domain.ServiceProvider;
using Bowling.Presentation;

namespace Bowling.DependencyInjector
{
    public class PresentationFactory
    {
        public static IUserInterface CreateUserInterface()
        {
            return new UserInterface(InfrastructureFactory.CreateUserInterface());
        }
    }
}
