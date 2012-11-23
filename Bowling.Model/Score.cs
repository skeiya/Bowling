
namespace Bowling.Domain.Model
{
    public class Score
    {
        private int _pin;

        public Score(int p)
        {
            this._pin = p;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return _pin.Equals(((Score)obj)._pin);
        }

        public override int GetHashCode()
        {
            return _pin.GetHashCode();
        }

        public override string ToString()
        {
            return _pin.ToString();
        }
             
    }
}
