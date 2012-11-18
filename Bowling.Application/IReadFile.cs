
namespace Bowling.Application
{
    public interface IReadFile
    {
        void Open(string path);

        string ReadLine();

        void Close();
    }
}
