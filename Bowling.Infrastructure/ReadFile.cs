using System.IO;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Infrastructure
{
    public class ReadFile : IReadFile
    {
        private StreamReader _stream;

        public void Open(string path)
        {
            _stream = new StreamReader(File.Open(path, FileMode.Open));
        }

        public string ReadLine()
        {
            return _stream.ReadLine();
        }

        public void Close()
        {
            _stream.Close();
        }
    }
}
