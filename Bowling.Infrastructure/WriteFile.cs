using System.IO;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Infrastructure
{
    public class WriteFile : IWriteFile
    {
        StreamWriter _stream;

        public void Open(string path)
        {
            if (File.Exists(path)) File.Delete(path);
            _stream = new StreamWriter(File.Open(path, FileMode.CreateNew));
        }

        public void Close()
        {
            _stream.Close();
        }

        public void Write(string p)
        {
            _stream.Write(p);
        }
    }
}
