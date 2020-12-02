using System.Linq;

namespace LibHashDB.Keys
{
    public abstract class Key
    {
        public abstract byte[] BinaryValue { get; }

        /*
            Coś jest nie tak z porównywaniem obiektów
        */
        public override bool Equals(object obj)
        {
            if (!(obj is Key))
                return false;

            Key key = obj as Key;

            return BinaryValue.SequenceEqual(key.BinaryValue);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Key a, Key b) { return a.Equals(b); }
        public static bool operator !=(Key a, Key b) { return !a.Equals(b); }
    }
}
