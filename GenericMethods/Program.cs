using System;

namespace GenericMethods
{
    class Program
    {
        private static void Display(String s)
        {
            Console.WriteLine(s);
        }
        private static void Display<T>(T o)
        {
            Display(o.ToString()); // Calls Display(String)
        }
        static void Main(string[] args)
        {
            Display("Jeff"); // Calls Display(String)
            Display(123); // Calls Display<T>(T)
            Display<String>("Aidan"); // Calls Display<T>(T)
        }
    }
}
