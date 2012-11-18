using System;
using Bowling.Application;
using Bowling.Model;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestSaveAndLoad
    {
        [TestMethod]
        public void Save()
        {
            FileSystemMock fileSystem = new FileSystemMock();

            Game game = new Game(fileSystem);
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
    }
}
