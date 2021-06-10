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

    internal struct Point_1 : IComparable
    {
        private readonly Int32 m_x, m_y;
        // Constructor to easily initialize the fields
        public Point_1(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }
        // Override ToString method inherited from System.ValueType
        public override String ToString()
        {
            // Return the point as a string. Note: calling ToString prevents boxing
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }
        // Implementation of type-safe CompareTo method
        public Int32 CompareTo(Point_1 other)
        {
            // Use the Pythagorean Theorem to calculate
            // which point is farther from the origin (0, 0)
            return Math.Sign(Math.Sqrt(m_x * m_x + m_y * m_y)
            - Math.Sqrt(other.m_x * other.m_x + other.m_y * other.m_y));
        }
        // Implementation of IComparable's CompareTo method
        public Int32 CompareTo(Object o)
        {
            if (GetType() != o.GetType())
            {
                throw new ArgumentException("o is not a Point");
            }
            // Call type-safe CompareTo method
            return CompareTo((Point)o);
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

            #region Point_1 Main
            // Create two Point_1 instances on the stack.
            Point_1 p1 = new Point_1(10, 10);
            Point_1 p2 = new Point_1(20, 20);
            // p1 does NOT get boxed to call ToString (a virtual method).
            Console.WriteLine(p1.ToString());// "(10, 10)"
                                             // p DOES get boxed to call GetType (a non-virtual method).
            Console.WriteLine(p1.GetType());// "Point_1"
            // p1 does NOT get boxed to call CompareTo.
            // p2 does NOT get boxed because CompareTo(Point) is called.
            Console.WriteLine(p1.CompareTo(p2));// "-1"
                                    // p1 DOES get boxed, and the reference is placed in c.
            IComparable c = p1;
            Console.WriteLine(c.GetType());// "Point"
                                           // p1 does NOT get boxed to call CompareTo.
                                           // Since CompareTo is not being passed a Point variable,
                                           // CompareTo(Object) is called which requires a reference to
                                           // a boxed Point.
                                           // c does NOT get boxed because it already refers to a boxed Point.
            Console.WriteLine(p1.CompareTo(c));// "0"
                                               // c does NOT get boxed because it already refers to a boxed Point.
                                               // p2 does get boxed because CompareTo(Object) is called.
            Console.WriteLine(c.CompareTo(p2));// "-1"
                                               // c is unboxed, and fields are copied into p2.
            p2 = (Point_1)c;
            // Proves that the fields got copied into p2.
            Console.WriteLine(p2.ToString());// "(10, 10)"
            #endregion
        }
    }
}
