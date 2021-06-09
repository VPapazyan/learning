using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndInheritance
{
    internal class Node
    {
        protected Node m_next;
        public Node(Node next)
        {
            m_next = next;
        }
    }
    internal sealed class TypedNode<T> : Node
    {
        public T m_data;
        public TypedNode(T data) : this(data, null)
        {
        }
        public TypedNode(T data, Node next) : base(next)
        {
            m_data = data;
        }
        public override String ToString()
        {
            return m_data.ToString() +
            ((m_next != null) ? m_next.ToString() : String.Empty);
        }
    }
}
