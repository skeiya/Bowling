using System;
using Bowling.Domain.Model;
using Bowling.Domain.ServiceProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestGame
    {
        [TestMethod]
        public void OneRoll()
        {
            Player game = new Player();
            game.Roll(2);
            Assert.AreEqual(new Score(2), game.CalcScore());
        }

        [TestMethod]
        public void TwoRoll()
        {
            Player game = new Player();
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(new Score(5), game.CalcScore());
        }

        [TestMethod]
        public void Spare()
        {
            Player game = new Player();
            game.Roll(2);
            game.Roll(8);
            game.Roll(2);
            game.Roll(3);
            Assert.AreEqual(new Score(17), game.CalcScore());
        }

        [TestMethod]
        public void Strike()
        {
            Player game = new Player();
            game.Roll(10);
            game.Roll(8);
            game.Roll(1);
            game.Roll(3);
            Assert.AreEqual(new Score(31), game.CalcScore());
        }

        [TestMethod]
        public void Perfect()
        {
            Player game = new Player();
            for (int i = 0; i < 12; i++) game.Roll(10);
            Assert.AreEqual(new Score(300), game.CalcScore());
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorOneRoll()
        {
            Player game = new Player();
            game.Roll(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorFrameOver()
        {
            Player game = new Player();
            game.Roll(2);
            game.Roll(9);
        }
    }
}
