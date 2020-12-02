using System.Collections.Generic;

using LibHashDB.Exceptions;
using LibHashDB.Keys;
using LibHashDB.Records;

namespace LibHashDB.Buckets
{
    public class Bucket
    {
        public int Index { get; private set; }

        public Record FirstRecord { get; private set; }

        public bool Empty
        {
            get
            {
                return FirstRecord == null;
            }
        }

        // returns the list of records associated with the bucket
        public List<Record> LinkedList
        {
            get
            {
                if (!Empty)
                    return FirstRecord.LinkedList;
                return new List<Record>();
            }
        }

        // returns the number of elements in the linked list associated with the bucket
        public int LinkedListSize
        {
            get
            {
                if (!Empty)
                    return FirstRecord.LinkedListSize;
                return 0;
            }
        }

        public Bucket(int index)
        {
            Index = index;
        }

        public void Insert(Record record)
        {
            if (Empty)
                FirstRecord = record;
            else
                FirstRecord.Insert(record);
        }

        public Record Select(Key key)
        {
            if (Empty)
                throw new NoValueException(key);

            return FirstRecord.Select(key);
        }
    }
}
