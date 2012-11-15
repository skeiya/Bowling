using System;
using Bowling.Application;
using Bowling.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestGame
    {
        [TestMethod]
        public void OneRoll()
        {
            Game game = new Game();
            game.Roll(2);
            Assert.AreEqual(new Score(2), game.CalcScore());
        }

        [TestMethod]
        public void TwoRoll()
        {
            Game game = new Game();
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(new Score(5), game.CalcScore());
        }

        [TestMethod]
        public void Spare()
        {
            Game game = new Game();
            game.Roll(2);
            game.Roll(8);
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(new Score(17), game.CalcScore());
        }

        [TestMethod]
        public void Strike()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);
            game.Roll(3);
            Assert.AreEqual(new Score(31), game.CalcScore());
        }

        [TestMethod]
        public void Perfect()
        {
            Game game = new Game();
            for (int i = 0; i < 12; i++) game.Roll(10);
            Assert.AreEqual(new Score(300), game.CalcScore());
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorOneRoll()
        {
            Game game = new Game();
            game.Roll(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorFrameOver()
        {
            Game game = new Game();
            game.Roll(2);
            game.Roll(9);
        }

        [TestMethod]
        public void Save()
        {
            Game game = new Game();
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);
            game.Roll(3);
            game.Save();
        }
    }
}
