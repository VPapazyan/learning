using System;
using System.Collections;

namespace BoxingAndUnboxing
{
    struct Point
    {
        public Int32 x, y;

        public override string ToString()
        {
            return $"Point: x={x} y={y}";
        }
    }
    public sealed class Program
    {
        public static void Main()
        {
            #region Boxing a struct
            ArrayList a = new ArrayList();

            Point p; // Allocate a Point (not in the heap).
            for (Int32 i = 0; i < 10; i++)
            {
                p.x = p.y = i; // Initialize the members in the value type.
                a.Add(p); // Box the value type and add the
                          // reference to the Arraylist.
            }

            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }

            Console.Read();
            #endregion

            #region Boxing-unboxing rules
            Int32 x = 5;
            Object o = x; // Box x; o refers to the boxed object
            Int16 y = (Int16)o; // Throws an InvalidCastException

            Int32 x1 = 5;
            Object o1 = x; // Box x; o refers to the boxed object
            Int16 y1 = (Int16)(Int32)o; // Unbox to the correct type and cast
            #endregion
        }
    }
}
