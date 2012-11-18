using Bowling.Presentation;

namespace UnitTestBowling
{
    class UserInterfaceMock : IUserInterface
    {
        private string _inputString;

        public UserInterfaceMock(string p)
        {
            this._inputString = p;
        }

        public void RequestInput()
        {
            // do nothing
        }

        public string AcceptInput()
        {
            return _inputString;
        }
    }
}
