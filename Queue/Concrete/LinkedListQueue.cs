using LinkedList.Doubly;
using Queue.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Concrete
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private DoublyLinkedList<T> _list;

        public LinkedListQueue()
        {
            _list = new DoublyLinkedList<T>();
        }

        public LinkedListQueue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }
        public int Count => _list.Count;

        public T Dequeue()
        {
            if (_list.Head == null) throw new Exception("Queue is empty!");
            return _list.RemoveFirst();

        }

        public void Enqueue(T item)
        {
            _list.AddLast(item);
        }

        public T Peek()
        {
            return _list.Head is null ? default(T) : _list.Head.Value;
        }
    }
}
