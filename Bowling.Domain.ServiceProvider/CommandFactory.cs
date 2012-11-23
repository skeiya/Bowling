using System;
using Bowling.Domain.Model;

namespace Bowling.Domain.ServiceProvider
{
    public class CommandFactory
    {
        public static ICommand CraeteFromUserInput(IUserInterface ui, IReadFile readFile, IWriteFile writeFile, Game game)
        {
            while (true)
            {
                ui.RequestInput();
                string inputStr = ui.AcceptInput();

                try
                {
                    if (inputStr[0] == 's' && inputStr[1] == ':')
                    {
                        return new CommandSave(game.GetFrames(), inputStr.Substring(2), writeFile);
                    }
                    if (inputStr[0] == 'l' && inputStr[1] == ':')
                    {
                        return new CommandLoad(game, inputStr.Substring(2), readFile);
                    }
                    if (inputStr.Length == 1 && inputStr[0] == 'q')
                    {
                        return new CommandQuit();
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
