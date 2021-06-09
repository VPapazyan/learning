using System;

namespace OtherMembers
{
    // It is OK to define the following types:
    //internal sealed class AType { }
    //internal sealed class AType<T> { }
    //internal sealed class AType<T1, T2> { }

    //// Error: conflicts with AType<T> that has no constraints
    //internal sealed class AType<T> where T : IComparable<T> { }

    //// Error: conflicts with AType<T1, T2>
    //internal sealed class AType<T3, T4> { }
    //internal sealed class AnotherType
    //{
    //    // It is OK to define the following methods:
    //    private static void M() { }
    //    private static void M<T>() { }
    //    private static void M<T1, T2>() { }
    //    // Error: conflicts with M<T> that has no constraints
    //    private static void M<T>() where T : IComparable<T> { }
    //    // Error: conflicts with M<T1, T2>
    //    private static void M<T3, T4>() { }
    //}

    //internal class Base
    //{
    //    public virtual void M<T1, T2>()
    //    where T1 : struct
    //    where T2 : class
    //    {
    //    }
    //}
    //internal sealed class Derived : Base
    //{
    //    public override void M<T3, T4>()
    //    where T3 : EventArgs // Error
    //    where T4 : class // Error.................... Why??
    //    { }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MethodTakingAnyType("5"));
        }

        private static Boolean MethodTakingAnyType<T>(T o)
        {
            T temp = o;
            Console.WriteLine(o.ToString());
            Boolean b = temp.Equals(o);
            return b;
        }

        // Will drop compile error
        //private static T Min<T>(T o1, T o2)
        //{
        //    if (o1.CompareTo(o2) < 0)
        //    {
        //        return o1;
        //    }
        //    return o2;
        //}

        public static T Min<T>(T o1, T o2) where T : IComparable<T>
        {
            if (o1.CompareTo(o2) < 0) return o1;
            return o2;
        }

        //private static void CallMin()
        //{
        //    Object o1 = "Jeff", o2 = "Richter";
        //    Object oMin = Min<Object>(o1, o2); // Error CS0311, System.Object doesn't implement IComparable<T>
        //}
    }
}
