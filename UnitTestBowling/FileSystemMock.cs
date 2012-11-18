using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Application;

namespace UnitTestBowling
{
    class FileSystemMock : IFileSystem
    {
        string _path;
        string _content = "";

        internal string GetPath()
        {
            return _path;
        }

        internal string GetContent()
        {
            return _content;
        }

        public void Open(string path)
        {
            _path = path;
        }

        public void Close()
        {
            // do nothing
        }

        public void Write(string p)
        {
            _content += p;
        }
    }
}
