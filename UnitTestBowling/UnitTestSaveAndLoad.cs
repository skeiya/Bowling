using Bowling.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestSaveAndLoad
    {
        [TestMethod]
        public void Save()
        {
            WriteFileMock fileSystem = new WriteFileMock();

            Game game = new Game(fileSystem, null);
            RollMany(game, 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 8, 1, 9, 1);

            string path = "C:\\data.txt"; 
            game.Save(path);

            Assert.AreEqual(path, fileSystem.GetPath());
            Assert.AreEqual("0,1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,", fileSystem.GetContent());
        }

        private void RollMany(Game game, params int[] pins)
        {
            foreach (int pin in pins) game.Roll(pin);
        }

        [TestMethod]
        public void Load()
        {
            ReadFileMock file = new ReadFileMock("0,1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,");

            Game game = new Game(null, file);

            string path = "C:\\data.txt";
            game.Load(path);

            Assert.AreEqual(path, file.GetPath());

            Game evidence = new Game();
            RollMany(evidence, 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 8, 1, 9, 1);
            Assert.AreEqual(game, evidence);
        }
    }
}
