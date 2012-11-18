using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Application
{
    public interface IWriteFile
    {
        void Open(string path);

        void Close();

        void Write(string p);
    }
}
