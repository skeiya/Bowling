using System;
using Bowling.Domain.ServiceProvider;

namespace Bowling.Presentation
{
    public class UserInterface : IUserInterface
    {
        private IMyConsole _console;

        private enum Task
        {
            Save,
            Load,
            Roll,
            Quit,
        }

        public UserInterface(IMyConsole console)
        {
            _console = console;
        }

        public void Show(IUserInterfaceCallBack callBack)
        {
            while (!callBack.IsEnd())
            {
                try
                {
                    _console.WriteLine("Please input integer (from 0 to 10). When save, s:C:\\work\\data.txt. When load, l:C:\\work\\data.txt");
                    string inputStr = _console.ReadLine();
                    Task t = GetTaskFromUserInput(inputStr);
                    switch (t)
                    {
                        case Task.Save:
                            callBack.Save(inputStr.Substring(2));
                            break;
                        case Task.Load:
                            callBack.Load(inputStr.Substring(2));
                            ScoreDrawer.Draw(callBack);
                            break;
                        case Task.Roll:
                            callBack.Roll(int.Parse(inputStr));
                            ScoreDrawer.Draw(callBack);
                            break;
                        case Task.Quit:
                            return;
                    }
                }
                catch (Exception)
                {
                }
            }
            Console.ReadKey();
        }

        private static Task GetTaskFromUserInput(string inputStr)
        {
            while (true)
            {
                try
                {
                    if (inputStr[0] == 's' && inputStr[1] == ':')
                    {
                        return Task.Save;
                    }
                    if (inputStr[0] == 'l' && inputStr[1] == ':')
                    {
                        return Task.Load;
                    }
                    if (inputStr.Length == 1 && inputStr[0] == 'q')
                    {
                        return Task.Quit;
                    }
                    int.Parse(inputStr);
                    return Task.Roll;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
