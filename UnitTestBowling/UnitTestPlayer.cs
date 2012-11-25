using System;
using Bowling.Domain.Model;
using Bowling.Domain.ServiceProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestPlayer
    {
        [TestMethod]
        public void OneRoll()
        {
            Player player = new Player();
            player.Roll(2);
            Assert.AreEqual(new Score(2), player.CalcScore());
        }

        [TestMethod]
        public void TwoRoll()
        {
            Player player = new Player();
            player.Roll(2);
            player.Roll(3);
            Assert.AreEqual(new Score(5), player.CalcScore());
        }

        [TestMethod]
        public void Spare()
        {
            Player player = new Player();
            player.Roll(2);
            player.Roll(8);
            player.Roll(2);
            player.Roll(3);
            Assert.AreEqual(new Score(17), player.CalcScore());
        }

        [TestMethod]
        public void Strike()
        {
            Player player = new Player();
            player.Roll(10);
            player.Roll(8);
            player.Roll(1);
            player.Roll(3);
            Assert.AreEqual(new Score(31), player.CalcScore());
        }

        [TestMethod]
        public void Perfect()
        {
            Player player = new Player();
            for (int i = 0; i < 12; i++) player.Roll(10);
            Assert.AreEqual(new Score(300), player.CalcScore());
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorOneRoll()
        {
            Player player = new Player();
            player.Roll(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ErrorFrameOver()
        {
            Player player = new Player();
            player.Roll(2);
            player.Roll(9);
        }
    }
}
