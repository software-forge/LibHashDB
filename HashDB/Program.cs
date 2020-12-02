using System;

using LibHashDB;
using LibHashDB.Buckets;

namespace HashDB
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Pomysł: ustawienie, dzięki któremu jeden klucz prowadzi do wielu wartości
                (bez nadpisywania)
            */

            HashTable table = new HashTable(BucketArraySize.Size256);

            table.Set("foo", "hop");
            table.Set("bar", "step");
            table.Set("baz", "jump");

            table.Print();

            table.Get("bar");
            Console.WriteLine(string.Format("Get(bar) = {0}", table.StringResult));

            table.Set("bar", "bebe");

            table.Get("bar");
            Console.WriteLine(string.Format("Get(bar) = {0}", table.StringResult));


            Console.ReadKey();
        }
    }
}
