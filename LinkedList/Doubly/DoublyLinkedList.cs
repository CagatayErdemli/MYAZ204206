using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Doubly
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public DbNode<T> Head { get; set; }
        public DbNode<T> Tail { get; set; }

        private bool _isHeadNull { get; set; }

        public DoublyLinkedList()
        {
            this._isHeadNull = true;
        }

        public DoublyLinkedList(IEnumerable<T> values)
        {
            _isHeadNull = true;
            foreach (var item in values)
            {
                AddLast(item);
            }
        }

        public void AddBefore(DbNode<T> node, T value)
        {
            if (node == null || value is null) throw new ArgumentNullException();
            if (_isHeadNull || node.Equals(Head))
            {
                AddFirst(value);
                return;
            }

            var newNode = new DbNode<T>(value);
            var current = Head;
            var prev = current;

            while (current is not null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    newNode.Prev = prev;
                    prev.Next = newNode;
                    newNode.Next.Prev = newNode;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("There is no such a node in the list.");

        }
        public void AddFirst(T item)
        {
            var node = new DbNode<T>(item);
            if (_isHeadNull)
            {
                Head = node;
                Tail = node;
                _isHeadNull = false;
                return;
            }

            Head.Prev = node;
            node.Next = Head;
            Head = node;
        }

        public void AddLast(T item)
        {
            var node = new DbNode<T>(item);
            if (_isHeadNull)
            {
                Head = node;
                Tail = node;
                _isHeadNull = false;
                return; 
            }

            Tail.Next = node;
            node.Prev = Tail;
            Tail = node;
        }

        public T RemoveFirst()
        {
            if (_isHeadNull) throw new Exception("List is empty!");
            T item = default(T);

            if (Head.Equals(Tail))
            {
                item = Head.Value;
                Head = null;
                Tail = null;
                return item;
            }

            item = Head.Value;
            Head = Head.Next;
            Head.Prev = null;
            return item;
        }

        public T RemoveLast()
        {
            if (_isHeadNull) throw new Exception("List is empty!");
            T item = Tail.Value;
            Tail = Tail.Prev;
            Tail.Next = null;
            return item;
        }

        public T Remove(T value)
        {
            if (_isHeadNull) throw new Exception("List is empty!");
            
            var current = Head;
            var prev = current;

            while (current!=null)
            {
                if (current.Value.Equals(value))
                {
                    if (current.Value.Equals(Head.Value)) return RemoveFirst();
                    if (current.Value.Equals(Tail.Value)) return RemoveLast();

                    var temp = current;
                    prev.Next = current.Next;
                    current.Next.Prev = current.Prev;
                    current = null;
                    return temp.Value;
                }
                prev = current;
                current = current.Next;
            }
            throw new ArgumentException("There is no such a this node in the list.");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
