using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bowling.Domain.Model;
using Bowling.Domain.Spec;
using Bowling.Presentation;

namespace UnitTestBowling
{
    [TestClass]
    public class UnitTestRollFormatter
    {

        [TestMethod]
        public void LastFrame1Roll_a()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(1));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" 1  ", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame1Roll_x()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" X  ", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame2Roll_xx()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(10));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" XX ", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame2Roll_xa()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(1));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" X1 ", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame2Roll_as()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(1));
            rolls.Add(new Roll(9));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" 1/ ", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame2Roll_ab()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(1));
            rolls.Add(new Roll(2));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" 1 2", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame3Roll_asb()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(1));
            rolls.Add(new Roll(9));
            rolls.Add(new Roll(2));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" 1/2", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame3Roll_asx()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(1));
            rolls.Add(new Roll(9));
            rolls.Add(new Roll(10));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" 1/X", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame3Roll_xab()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(1));
            rolls.Add(new Roll(2));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" X12", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame3Roll_xas()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(1));
            rolls.Add(new Roll(9));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" X1/", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame3Roll_xxa()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(1));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" XX1", RollFormatter.GetRollsOfFrame(f));
        }

        [TestMethod]
        public void LastFrame3Roll_xxx()
        {
            List<Roll> rolls = new List<Roll>();
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(10));
            rolls.Add(new Roll(10));

            Frame f = new Frame(FrameCountRule.GetCount() - 1, rolls);
            Assert.AreEqual(" XXX", RollFormatter.GetRollsOfFrame(f));
        }
    }
}
