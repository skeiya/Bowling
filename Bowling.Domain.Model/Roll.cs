
namespace Bowling.Domain.Model
{
    public class Roll
    {
        private readonly int _pin;

        public Roll(int p)
        {
            this._pin = p;
        }

        public int GetPin()
        {
            return _pin;
        }

        public object Clone()
        {
            return new Roll(_pin);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return this._pin.Equals(((Roll)obj)._pin);
        }

        public override int GetHashCode()
        {
            return _pin.GetHashCode();
        }
    }
}
