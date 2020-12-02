using System.Text;

using LibHashDB.Keys;

namespace LibHashDB.Records
{
    public class StringRecord : Record
    {
        public StringRecord(StringKey key, string value)
        {
            Key = key;
            Value = Encoding.UTF8.GetBytes(value);
        }

        public StringRecord(StringKey key, byte[] value)
        {
            Key = key;
            Value = value;
        }
    }
}
