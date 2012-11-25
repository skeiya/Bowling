using Bowling.Domain.ServiceProvider;

namespace UnitTestBowling
{
    class WriteFileMock : IWriteFile
    {
        string _content = "";

        internal string GetContent()
        {
            return _content;
        }

        public void Open(string path)
        {
            // do nothing
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
