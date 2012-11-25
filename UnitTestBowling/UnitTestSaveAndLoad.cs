using Bowling.Domain.Model;
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
            int[] pins = { 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 8, 1, 9, 1 };
            Frames frames = RollMany(10, pins);
            WriteFileMock writeFile = new WriteFileMock();
            SaveService.Save(frames, "C:\\data.txt", writeFile);
            Assert.AreEqual("0,1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,", writeFile.GetContent());
        }

        [TestMethod]
        public void Load()
        {
            ReadFileMock fileRead = new ReadFileMock("0,1,1,1,2,1,3,1,4,1,5,1,6,1,7,1,8,1,9,1,");
            Frames frames = LoadService.Load("C:\\data.txt", fileRead);

            Frames evidence = RollMany(10, 0, 1, 1, 1, 2, 1, 3, 1, 4, 1, 5, 1, 6, 1, 7, 1, 8, 1, 9, 1);
            Assert.AreEqual(frames, evidence);
        }

        private Frames RollMany(int maxFrameCount, params int[] pins)
        {
            Frames frames = new Frames(maxFrameCount);
            foreach (int pin in pins)
            {
                frames = RollService.Roll(frames, pin);
            }
            return frames;
        }

    }
}
