using System;

namespace NullableTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Int32? n = null;
            Object o = n; // o is null
            Console.WriteLine("o is null={0}", o == null); // "True"
            n = 5;
            o = n; // o refers to a boxed Int32
            Console.WriteLine("o's type={0}", o.GetType()); // "System.Int32"
        }
    }
}
