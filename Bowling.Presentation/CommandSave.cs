using Bowling.Application;

namespace Bowling.Presentation
{
    public class CommandSave : ICommand
    {
        private Game _game;
        private string _path;

        public CommandSave(Game game, string p)
        {
            this._game = game;
            this._path = p;
        }

        public void Exec()
        {
            _game.Save(_path);
        }
    }
}
