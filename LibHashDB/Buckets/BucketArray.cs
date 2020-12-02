using System;

using LibHashDB.Keys;
using LibHashDB.Records;

namespace LibHashDB.Buckets
{
    public class BucketArray
    {
        public Bucket[] Buckets { get; private set; }
        public BucketArraySize Size { get; private set; }

        public BucketArray(BucketArraySize size)
        {
            Size = size;

            int c = (int) Size;

            Buckets = new Bucket[c];

            for (int i = 0; i < c; i++)
                Buckets[i] = new Bucket(i);
        }

        public void Insert(Record record, int index)
        {
            int c = (int) Size;

            if (index < 0 || index > c - 1)
                throw new Exception("index out of range");

            Buckets[index].Insert(record);
        }

        public Record Select(Key key, int index)
        {
            int c = (int) Size;

            if (index < 0 || index > c - 1)
                throw new Exception("index out of range");

            return Buckets[index].Select(key);
        }
    }
}
