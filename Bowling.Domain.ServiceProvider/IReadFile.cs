
namespace Bowling.Domain.ServiceProvider
{
    public interface IReadFile
    {
        void Open(string path);

        string ReadLine();

        void Close();
    }
}
