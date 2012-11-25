using Bowling.Domain.ServiceProvider;

namespace UnitTestBowling
{
    class ReadFileMock : IReadFile
    {
        private string _content;

        public ReadFileMock(string p)
        {
            this._content = p;
        }

        public void Open(string path)
        {
            // do nothing
        }

        public string ReadLine()
        {
            return _content;
        }

        public void Close()
        {
            // do nothing
        }
    }
}
