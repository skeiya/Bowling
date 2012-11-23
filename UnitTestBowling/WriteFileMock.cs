using Bowling.Domain.ServiceProvider;

namespace UnitTestBowling
{
    class WriteFileMock : IWriteFile
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
