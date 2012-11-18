﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Application;

namespace UnitTestBowling
{
    class ReadFileMock : IReadFile
    {
        private string _content;
        private string _path;

        public ReadFileMock(string p)
        {
            this._content = p;
        }

        internal string GetPath()
        {
            return _path;
        }

        public void Open(string path)
        {
            _path = path;
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
