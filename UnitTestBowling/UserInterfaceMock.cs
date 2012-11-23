using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Domain.ServiceProvider;

namespace UnitTestBowling
{
    class UserInterfaceMock : IUserInterface
    {
        private List<string> _list = new List<string>();
        private int _i = 0;

        public UserInterfaceMock(string p)
        {
            _list.Add(p);
        }

        public UserInterfaceMock()
        {
        }

        internal void AddContent(params string[] list)
        {
            foreach (string str in list) _list.Add(str);
        }

        public void RequestInput()
        {
            // do nothing
        }

        public string AcceptInput()
        {
            return _list[_i++];
        }
    }
}
