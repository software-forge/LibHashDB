using System.Text;

namespace LibHashDB.Keys
{
    public class StringKey : Key
    {
        public string Value { get; private set; }

        public override byte[] BinaryValue
        {
            get
            {
                return Encoding.UTF8.GetBytes(Value);
            }
        }

        public StringKey(string value)
        {
            Value = value;
        }
    }
}
