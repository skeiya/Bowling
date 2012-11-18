using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
