using System;
using System.Text;
using System.Security.Cryptography;

using LibHashDB.Buckets;

namespace LibHashDB.Utilities
{
    public static class Hasher
    {
        public static ushort Hash(string key, BucketArraySize size)
        {
            return Hash(Encoding.UTF8.GetBytes(key), size);
        }

        public static ushort Hash(byte[] key, BucketArraySize size)
        {
            // compute the hash value of the key
            byte[] hash = ComputeSha256(key);

            // grab the first two bytes of the hash to an unsigned short
            ushort firstUShort = BitConverter.ToUInt16(hash, 0);

            // derive the bitmask value from size of bucket array
            ushort mask = Convert.ToUInt16(((int) size) - 1);

            // return the required bits
            return Convert.ToUInt16(firstUShort & mask);
        }

        public static byte[] ComputeSha256(string input)
        {
            return ComputeSha256(Encoding.UTF8.GetBytes(input));
        }

        public static byte[] ComputeSha256(byte[] input)
        {
            byte[] hash = new byte[32];

            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(input);
            }

            return hash;
        }
    }
}
