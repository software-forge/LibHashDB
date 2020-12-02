using System.Text;

using LibHashDB.Keys;

namespace LibHashDB.Records
{
    public class BinaryRecord : Record
    {
        public BinaryRecord(BinaryKey key, string value)
        {
            Key = key;
            Value = Encoding.UTF8.GetBytes(value);
        }

        public BinaryRecord(BinaryKey key, byte[] value)
        {
            Key = key;
            Value = value;
        }
    }
}
