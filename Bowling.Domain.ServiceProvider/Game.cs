using Bowling.ServiceProvider;

namespace Bowling.Domain.ServiceProvider
{
    public class Game
    {
        private IUserInterface _userInterface;
        private IWriteFile _writeFile;
        private IReadFile _readFile;

        private Player _player = new Player();

        public Game(IUserInterface userInterface, IWriteFile writeFile, IReadFile readFile)
        {
            this._userInterface = userInterface;
            this._writeFile = writeFile;
            this._readFile = readFile;
        }

        public void Start()
        {
            _userInterface.Show(new CallBack(this, _writeFile, _readFile));
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public bool IsEnd()
        {
            return _player.IsEnd();
        }
    }
}
