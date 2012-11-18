using System;
using Bowling.Presentation;

namespace Infrastructure
{
    public class UserInterface : IUserInterface
    {
        public void RequestInput()
        {
            Console.WriteLine("Please input integer (from 0 to 10). When save, s:C:\\work\\data.txt. When load, l:C:\\work\\data.txt");
        }

        public string AcceptInput()
        {
            return Console.ReadLine();
        }
    }
}
