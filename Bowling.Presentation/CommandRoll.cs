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
    class CommandRoll : ICommand
    {
        private Game _game;
        private int _pin;

        public CommandRoll(Game game, int pin)
        {
            _game = game;
            _pin = pin;
        }

        public void Exec()
        {
            _game.Roll(_pin);

            WriteFrameNumber();
            WriteRolls(_game);
            WriteScores(_game);
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
