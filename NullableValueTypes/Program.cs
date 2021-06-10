using System;

namespace NullableValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region begining
            Int32? n = null;
            Object o = n; // o is null
            Console.WriteLine("o is null={0}", o == null); // "True"
            n = 5;
            o = n; // o refers to a boxed Int32
            Console.WriteLine("o's type={0}", o.GetType()); // "System.Int32"
            #endregion

            #region Unboxing nullable value types
            // Create a boxed Int32
            Object ob = 5;
            // Unbox it into a Nullable<Int32> and into an Int32
            Int32? a = (Int32?)ob; // a = 5
            Int32 b = (Int32)ob; // b = 5
                                // Create a reference initialized to null
            o = null;
            // "Unbox" it into a Nullable<Int32> and into an Int32
            a = (Int32?)ob; // a = null
            b = (Int32)ob; // NullReferenceException
            #endregion
        }
    }
}
