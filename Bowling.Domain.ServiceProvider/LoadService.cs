using Bowling.Domain.Model;
using Bowling.Domain.Spec;

namespace Bowling.Domain.ServiceProvider
{
    public class LoadService
    {
        public static Frames Load(string path, IReadFile readFile)
        {
            Frames frames = new Frames(FrameCountRule.GetCount());
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
