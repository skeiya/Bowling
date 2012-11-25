using Bowling.Domain.Model;
using Bowling.Domain.ServiceProvider;
using Bowling.Presentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestCommandFactory
    {
        [TestMethod]
        public void CreateCommandRoll()
        {
            Player player = new Player();
            IUserInterface ui = new UserInterfaceMock("3");
            ICommand c = CommandFactory.CraeteFromUserInput(ui, null, null, player);
            Assert.IsInstanceOfType(c, typeof(CommandRoll));
        }

        [TestMethod]
        public void CreateCommandSave()
        {
            Player player = new Player();
            IUserInterface ui = new UserInterfaceMock("s:C:\\work\\data.txt");
            ICommand c = CommandFactory.CraeteFromUserInput(ui, null, null, player);
            Assert.IsInstanceOfType(c, typeof(CommandSave));
        }

        [TestMethod]
        public void CreateCommandLoad()
        {
            Player player = new Player();
            IUserInterface ui = new UserInterfaceMock("l:C:\\work\\data.txt");
            ICommand c = CommandFactory.CraeteFromUserInput(ui, null, null, player);
            Assert.IsInstanceOfType(c, typeof(CommandLoad));
        }
    }
}
