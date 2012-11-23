using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Domain.ServiceProvider
{
    public class CommandQuit:ICommand
    {
        public void Exec()
        {
            // do nothing
        }
    }
}
