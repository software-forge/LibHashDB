using LibHashDB.Keys;
using LibHashDB.Buckets;

namespace LibHashDB.Utilities
{
    public static class KeyHasher
    {
        public static ushort HashKey(Key key, BucketArraySize size)
        {
            return Hasher.Hash(key.BinaryValue, size);
        }
    }
}
