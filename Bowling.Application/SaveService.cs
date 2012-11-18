using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Model;

namespace Bowling.Application
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
