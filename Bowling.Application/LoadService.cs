using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;

namespace Bowling.Application
{
    public class LoadService
    {
        internal static Frames Load(Frames frames, string path, IReadFile readFile)
        {
            try
            {
                readFile.Open(path);
                string content = readFile.ReadLine();
                foreach (string str in content.Split(','))
                {
                    if (str == "") break;
                    frames = RollService.Roll(frames, int.Parse(str));
                }
            }
            finally
            {
                readFile.Close();
            }
            return frames;
        }
    }
}
