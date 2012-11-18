
namespace Bowling.Application
{
    public interface IWriteFile
    {
        void Open(string path);

        void Close();

        void Write(string p);
    }
}
