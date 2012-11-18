using Bowling.Application;
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
            Game game = new Game();
            IUserInterface ui = new UserInterfaceMock("3");
            ICommand c = CommandFactory.CraeteFromUserInput(ui, game);
            Assert.IsInstanceOfType(c, typeof(CommandRoll));
        }

        [TestMethod]
        public void CreateCommandSave()
        {
            Game game = new Game();
            IUserInterface ui = new UserInterfaceMock("s:C:\\work\\data.txt");
            ICommand c = CommandFactory.CraeteFromUserInput(ui, game);
            Assert.IsInstanceOfType(c, typeof(CommandSave));
        }

        [TestMethod]
        public void CreateCommandLoad()
        {
            Game game = new Game();
            IUserInterface ui = new UserInterfaceMock("l:C:\\work\\data.txt");
            ICommand c = CommandFactory.CraeteFromUserInput(ui, game);
            Assert.IsInstanceOfType(c, typeof(CommandLoad));
        }
    }
}
