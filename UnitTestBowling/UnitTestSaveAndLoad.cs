using Bowling.Domain.ServiceProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestSaveAndLoad
    {
        [TestMethod]
        public void Save()
        {
            WriteFileMock writeFile = new WriteFileMock();
            UserInterfaceMock ui = new UserInterfaceMock();
            ui.AddContent("0", "1", "1", "1", "2", "1", "3", "1", "4", "1", "5", "1", "6", "1", "7", "1", "8", "1", "9", "1");
            ui.AddContent("s:C:\\data.txt");
            ui.AddContent("q");

            Game game = new Game(ui, writeFile, null);
            game.Start();

            Assert.AreEqual("0,1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,", writeFile.GetContent());
        }

        private void RollMany(Player game, params int[] pins)
        {
            foreach (int pin in pins) game.Roll(pin);
        }

        [TestMethod]
        public void Load()
        {
            ReadFileMock fileRead = new ReadFileMock("0,1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,");
            UserInterfaceMock ui = new UserInterfaceMock("l:C:\\data.txt");
            ui.AddContent("q");
            Game game = new Game(ui, null, fileRead);
            game.Start();

            Player evidence = new Player();
            RollMany(evidence, 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 8, 1, 9, 1);
            Assert.AreEqual(game.GetPlayer(), evidence);
        }
    }
}
