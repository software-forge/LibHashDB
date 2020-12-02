using System;
using System.Text;

using LibHashDB.Keys;

namespace LibHashDB.Exceptions
{
    public class NoValueException : Exception
    {
        public string Key { get; private set; }

        public override string Message
        {
            get
            {
                return string.Format("no value for key '{0}' is stored in database", Key);
            }
        }

        public NoValueException(string key)
        {
            Key = key;
        }

        public NoValueException(Key key)
        {
            Key = Encoding.UTF8.GetString(key.BinaryValue);
        }
    }
}
