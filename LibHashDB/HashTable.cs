using System;
using System.Text;

using LibHashDB.Buckets;
using LibHashDB.Exceptions;
using LibHashDB.Utilities;
using LibHashDB.Keys;
using LibHashDB.Records;

namespace LibHashDB
{
    public class HashTable
    {
        public BucketArray BucketArray { get; private set; }
        public BucketArraySize BucketArraySize
        {
            get
            {
                return BucketArray.Size;
            }
        }

        public HashTable(BucketArraySize size)
        {
            BucketArray = new BucketArray(size);
        }

        public void Set(string key, string value)
        {
            StringKey stringKey = new StringKey(key);

            StringRecord stringRecord = new StringRecord(stringKey, value);

            int index = KeyHasher.HashKey(stringKey, BucketArraySize);

            BucketArray.Insert(stringRecord, index);
        }

        public void Set(string key, byte[] value)
        {
            StringKey stringKey = new StringKey(key);

            StringRecord stringRecord = new StringRecord(stringKey, value);

            int index = KeyHasher.HashKey(stringKey, BucketArraySize);

            BucketArray.Insert(stringRecord, index);
        }

        public void Set(byte[] key, string value)
        {
            BinaryKey binaryKey = new BinaryKey(key);

            BinaryRecord binaryRecord = new BinaryRecord(binaryKey, value);

            int index = KeyHasher.HashKey(binaryKey, BucketArraySize);

            BucketArray.Insert(binaryRecord, index);
        }

        public void Set(byte[] key, byte[] value)
        {
            BinaryKey binaryKey = new BinaryKey(key);

            BinaryRecord binaryRecord = new BinaryRecord(binaryKey, value);

            int index = KeyHasher.HashKey(binaryKey, BucketArraySize);

            BucketArray.Insert(binaryRecord, index);
        }

        public string StringResult
        {
            get
            {
                return Encoding.UTF8.GetString(BinaryResult);
            }
        }

        public byte[] BinaryResult { get; private set; }

        public void Get(string key)
        {
            StringKey stringKey = new StringKey(key);

            Record record;

            int index = KeyHasher.HashKey(stringKey, BucketArraySize);

            try
            {
                record = BucketArray.Select(stringKey, index);
                BinaryResult = record.Value;
            }
            catch(NoValueException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Get(byte[] key)
        {
            BinaryKey binaryKey = new BinaryKey(key);

            Record record;

            int index = KeyHasher.HashKey(binaryKey, BucketArraySize);

            try
            {
                record = BucketArray.Select(binaryKey, index);
                BinaryResult = record.Value;
            }
            catch(NoValueException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Print()
        {
            foreach(Bucket b in BucketArray.Buckets)
            {
                string bucketDesc = string.Format("{0} - ", b.Index);
                if(b.Empty)
                    bucketDesc += "<empty>";
                else
                {
                    bucketDesc += string.Format("Count: {0}; ", b.LinkedListSize);
                    foreach(Record r in b.LinkedList)
                    {
                        string key = Encoding.UTF8.GetString(r.Key.BinaryValue);
                        string value = Encoding.UTF8.GetString(r.Value);
                        bucketDesc += string.Format("Key: {0}, Value {1}; ", key, value);
                    }
                        
                }
                Console.WriteLine(bucketDesc);
            }
        }
    }
}
