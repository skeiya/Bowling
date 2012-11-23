using Bowling.Domain.Model;

namespace Bowling.Domain.ServiceProvider
{
    public class SaveService
    {
        public static void Save(Frames frames, string path, IWriteFile fileSystem)
        {
            try
            {
                fileSystem.Open(path);
                foreach (int pin in frames.GetPins())
                {
                    fileSystem.Write(pin.ToString() + ",");
                }
            }
            finally
            {
                fileSystem.Close();
            }
        }
    }
}
