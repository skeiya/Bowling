using System;
using Bowling.Application;

namespace Bowling.Presentation
{
    public class CommandFactory
    {
        public static ICommand CraeteFromUserInput(IUserInterface ui, Game game)
        {
            while (true)
            {
                ui.RequestInput();
                string inputStr = ui.AcceptInput();

                try
                {
                    if (inputStr[0] == 's' && inputStr[1] == ':')
                    {
                        return new CommandSave(game, inputStr.Substring(2));
                    }
                    if (inputStr[0] == 'l' && inputStr[1] == ':')
                    {
                        return new CommandLoad(game, inputStr.Substring(2));
                    }
                    return new CommandRoll(game, int.Parse(inputStr));
                }
                catch (Exception)
                {
                }
            }
        }
    }

}
