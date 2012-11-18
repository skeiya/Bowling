using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application;

namespace Infrastructure
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
