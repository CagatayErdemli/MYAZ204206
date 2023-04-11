using LinkedList.Singly;
using Stack.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Concrete
{
    public class LinkedListStack<T> : IStack<T>
    {
        private SinglyLinkedList<T> _innerList;

        public LinkedListStack()
        {
            _innerList = new SinglyLinkedList<T>();
        }
        public int Count => _innerList.Count;

        public T Peek()
        {
            return _innerList.Head is null
                ? default(T)
                : _innerList.Head.Value;
        }

        public T Pop()
        {
            return _innerList.RemoveFirst();
        }

        public void Push(T item)
        {
            _innerList.AddFirst(item);
        }
    }
}
