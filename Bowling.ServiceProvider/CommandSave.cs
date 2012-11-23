using Bowling.Domain.Model;

namespace Bowling.Domain.ServiceProvider
{
    public class CommandSave : ICommand
    {
        private Frames _frames;
        private string _path;
        private IWriteFile _writeFile;

        public CommandSave(Frames frames, string p, IWriteFile writeFile)
        {
            this._frames = frames;
            this._path = p;
            this._writeFile = writeFile;
        }

        public void Exec()
        {
            SaveService.Save(_frames, _path, _writeFile);
        }
    }
}
