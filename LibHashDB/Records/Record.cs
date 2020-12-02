using System.Collections.Generic;

using LibHashDB.Keys;

namespace LibHashDB.Records
{
    public abstract class Record
    {
        public Key Key { get; protected set; }
        public byte[] Value { get; protected set; }

        public Record NextRecord { get; protected set; }

        public bool HasNext
        {
            get
            {
                return NextRecord != null;
            }
        }

        public int LinkedListSize
        {
            get
            {
                if (!HasNext)
                    return 1;
                return 1 + NextRecord.LinkedListSize;
            }
        }

        public List<Record> LinkedList
        {
            get
            {
                List<Record> linkedList = new List<Record>();
                linkedList.Add(this);

                if (!HasNext)
                    return linkedList;
                else
                    linkedList.AddRange(NextRecord.LinkedList);

                return linkedList;
            }
        }

        public void Insert(Record record)
        {
            if (NextRecord == null)
                NextRecord = record;
            else
            {
                if (record.Key == Key)
                    Value = record.Value;
                else
                    NextRecord.Insert(record);
            }
        }

        public Record Select(Key key)
        {
            if (Key == key)
                return this;
            else
                return NextRecord.Select(key);
        }
    }
}
