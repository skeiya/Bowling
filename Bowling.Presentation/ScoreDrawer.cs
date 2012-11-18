using System;
using System.Text;
using Bowling.Application;
using Bowling.Model;
using Bowling.Spec;

namespace Bowling.Presentation
{
    class ScoreDrawer
    {
        internal static void Draw(Game game)
        {
            WriteFrameNumber();
            WriteRolls(game);
            WriteScores(game);
        }

        private static void WriteScores(Game game)
        {
            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < FrameCountRule.GetCount(); i++)
            {
                if (!game.IsFullAt(i)) continue;
                buf.AppendFormat("{0,4}", game.CalcScoreAt(i));
            }
            Console.WriteLine(buf);
        }

        private static void WriteRolls(Game game)
        {
            StringBuilder buf = new StringBuilder();
            foreach (Frame f in game.GetFrames())
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
