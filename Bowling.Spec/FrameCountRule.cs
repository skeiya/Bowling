using Bowling.Domain.Model;

namespace Bowling.Domain.Spec
{
    public class FrameCountRule
    {
        public static int GetCount()
        {
            return 10;
        }

        public static bool IsLastFrame(Frame f)
        {
            return f.GetFrameIndex() == GetCount() - 1;
        }
    }
}
