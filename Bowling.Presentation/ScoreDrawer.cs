using System;
using System.Text;
using Bowling.Domain.Model;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Presentation
{
    class ScoreDrawer
    {
        internal static void Draw(IUserInterfaceCallBack callBack)
        {
            WriteFrameNumber(callBack);
            WriteRolls(callBack);
            WriteScores(callBack);
        }

        private static void WriteScores(IUserInterfaceCallBack callBack)
        {
            StringBuilder buf = new StringBuilder();
            foreach (Score score in callBack.GetScores())
            {
                buf.AppendFormat("{0,4}", score);
            }
            Console.WriteLine(buf);
        }

        private static void WriteRolls(IUserInterfaceCallBack callBack)
        {
            StringBuilder buf = new StringBuilder();
            foreach (Frame f in callBack.GetFrames())
            {
                buf.Append(RollFormatter.GetRollsOfFrame(f));
            }
            Console.WriteLine(buf);
        }

        private static void WriteFrameNumber(IUserInterfaceCallBack callBack)
        {
            StringBuilder buf = new StringBuilder();
            foreach (int frameNumber in callBack.GetFrameNumbers())
            {
                buf.AppendFormat("{0,4}", frameNumber);
            }
            Console.WriteLine(buf);
        }
    }
}
