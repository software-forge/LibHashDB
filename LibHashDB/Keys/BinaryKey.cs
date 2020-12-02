namespace LibHashDB.Keys
{
    public class BinaryKey : Key
    {
        public byte[] Value { get; private set; }

        public override byte[] BinaryValue
        {
            get
            {
                return Value;
            }
        }

        public BinaryKey(byte[] value)
        {
            Value = value;
        }
    }
}
