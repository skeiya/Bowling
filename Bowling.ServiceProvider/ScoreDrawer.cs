using System;
using System.Text;
using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Domain.ServiceProvider
{
    class ScoreDrawer
    {
        internal static void Draw(Frames frames)
        {
            WriteFrameNumber();
            WriteRolls(frames);
            WriteScores(frames);
        }

        private static void WriteScores(Frames frames)
        {
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < FrameCountRule.GetCount(); i++)
            {
                if (!FullFrameRule.IsFull(frames[i])) continue;
                buf.AppendFormat("{0,4}", ScoreService.CalcAt(frames, i));
            }
            Console.WriteLine(buf);
        }

        private static void WriteRolls(Frames frames)
        {
            StringBuilder buf = new StringBuilder();
            foreach (Frame f in frames)
            {
                buf.Append(RollFormatter.GetRollsOfFrame(f));
            }
            Console.WriteLine(buf);
        }

        private static void WriteFrameNumber()
        {
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < FrameCountRule.GetCount(); i++)
            {
                buf.AppendFormat("{0,4}", i + 1);
            }
            Console.WriteLine(buf);
        }
    }
}
