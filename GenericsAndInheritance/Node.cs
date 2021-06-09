using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndInheritance
{
    internal sealed class Node<T>
    {
        public T m_data;
        public Node<T> m_next;
        public Node(T data) : this(data, null)
        {
        }
        public Node(T data, Node<T> next)
        {
            m_data = data; m_next = next;
        }
        public override String ToString()
        {
            return m_data.ToString() +
            ((m_next != null) ? m_next.ToString() : String.Empty);
        }
    }
}
