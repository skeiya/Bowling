using Bowling.Domain.Model;

namespace Bowling.Domain.ServiceProvider
{
    public class LoadService
    {
        public static Frames Load(Frames frames, string path, IReadFile readFile)
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
