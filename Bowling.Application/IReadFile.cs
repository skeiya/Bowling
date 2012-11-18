using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Application
{
    public interface IReadFile
    {
        void Open(string path);

        string ReadLine();

        void Close();
    }
}
