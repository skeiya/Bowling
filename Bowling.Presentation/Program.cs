using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application;
using Bowling.Model;
using Bowling.Spec;

namespace Bowling.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            while (!game.IsEnd())
            {
                Roll(game);

                WriteFrameNumber();
                WriteRolls(game);
                WriteScores(game);
            }
            Console.ReadKey();
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
                buf.Append(GetRollsOfFrame(f));
            }
            Console.WriteLine(buf);
        }

        private static string GetRollsOfFrame(Frame f)
        {
            if (StrikeRule.IsStrike(f))
            {
                return "   X";
            }
            if (SpareRule.IsSpare(f))
            {
                return string.Format("{0,2}", f[0].GetPin()) + " /";
            }
            StringBuilder buf = new StringBuilder();
            foreach (int pin in f.GetPins())
            {
                buf.AppendFormat("{0,2}", pin);
            }
            return buf.ToString();
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

        private static void Roll(Game game)
        {
            game.Roll(GetPinFromUserInput());
        }

        private static int GetPinFromUserInput()
        {
            while (true)
            {
                Console.WriteLine("Please input integer (from 0 to 10).");
                try
                {
                    string inputStr = Console.ReadLine();
                    return int.Parse(inputStr);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
