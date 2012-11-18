using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Application;

namespace Infrastructure
{
    public class FileSystem : IFileSystem
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
