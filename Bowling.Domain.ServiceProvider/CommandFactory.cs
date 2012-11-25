using System;
using Bowling.Domain.Model;

namespace Bowling.Domain.ServiceProvider
{
    public class CommandFactory
    {
        public static ICommand CraeteFromUserInput(IMyConsole ui, IReadFile readFile, IWriteFile writeFile, Player player)
        {
            while (true)
            {
                ui.RequestInput();
                string inputStr = ui.AcceptInput();

                try
                {
                    if (inputStr[0] == 's' && inputStr[1] == ':')
                    {
                        return new CommandSave(player.GetFrames(), inputStr.Substring(2), writeFile);
                    }
                    if (inputStr[0] == 'l' && inputStr[1] == ':')
                    {
                        return new CommandLoad(player, inputStr.Substring(2), readFile);
                    }
                    if (inputStr.Length == 1 && inputStr[0] == 'q')
                    {
                        return new CommandQuit();
                    }
                    return new CommandRoll(player, int.Parse(inputStr));
                }
                catch (Exception)
                {
                }
            }
        }
    }

}
