using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypePerfTest();
            ReferenceTypePerfTest();
        }

        private static void SomeMethod()
        {
            List<DateTime> dtList = new List<DateTime>();
            dtList.Add(DateTime.Now); // No boxing
            dtList.Add(DateTime.MinValue); // No boxing
            dtList.Add(new DateTime(1, 1, 2004)); 

            DateTime dt = dtList[0]; // No cast required
        }

        private static void ValueTypePerfTest()
        {
            const Int32 count = 100000000;
            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<Int32>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n); // No boxing
                    Int32 x = l[n]; // No unboxing
                }
                l = null; // Make sure this gets GC'd
            }
            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add(n); // Boxing
                    Int32 x = (Int32)a[n]; // Unboxing
                }
                a = null; // Make sure this gets GC'd
            }
        }

        private static void ReferenceTypePerfTest()
        {
            const Int32 count = 100000000;
            using (new OperationTimer("List<String>"))
            {
                List<String> l = new List<String>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("X"); // Reference copy 
                    String x = l[n]; // Reference copy
                }
                l = null; // Make sure this gets GC'd
            }
            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add("X"); // Reference copy
                    String x = (String)a[n]; // Cast check & reference copy
                }
                a = null; // Make sure this gets GC'd
            }
        }
    }
}

