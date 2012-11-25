using System.Collections.Generic;
using Bowling.Domain.Model;

namespace Bowling.Domain.ServiceProvider
{
    public interface IUserInterfaceCallBack
    {
        bool IsEnd();
        void Save(string p);
        void Load(string p);
        void Roll(int p);
        IEnumerable<Score> GetScores();
        IEnumerable<int> GetFrameNumbers();
        IEnumerable<Frame> GetFrames();
    }
}
