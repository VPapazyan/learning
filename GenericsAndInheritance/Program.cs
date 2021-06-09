using System;
using System.Collections.Generic;

namespace GenericsAndInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            SameDataLinkedList();
            DifferentDataLinkedList();

        }

        private static void SameDataLinkedList()
        {
            Node<Char> head = new Node<Char>('C');
            head = new Node<Char>('B', head);
            head = new Node<Char>('A', head);
            Console.WriteLine(head.ToString()); // Displays "ABC"
        }

        private static void DifferentDataLinkedList()
        {
            Node head = new TypedNode<Char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("Today is ", head);
            Console.WriteLine(head.ToString());
        }
    }
}
