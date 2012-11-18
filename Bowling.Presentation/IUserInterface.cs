using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Presentation
{
    public interface IUserInterface
    {
        void RequestInput();
        string AcceptInput();
    }
}
