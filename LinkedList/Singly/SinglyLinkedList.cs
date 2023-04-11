using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList.Singly
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedListNode<T>? Head { get; set; }

        public int Count { get; private set; }


        public SinglyLinkedList()
        {

        }

        public void AddFirst(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);

            if(Head is null)
            {
                Head = node;
                Count++;
                return;
            }

            node.Next = Head;
            Head = node;
            Count++;
            return;
        }

        public void AddLast(T item)
        {
            var node = new SinglyLinkedListNode<T>(item);
            if (Head is null)
            {
                Head = node;
                Count++;
                return;
            }

            var current = Head;
            var prev = current;
            while (current!=null)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = node;
            Count++;
            return;
        }

        public void AddBefore(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(item);
            var current = Head;
            var prev = current;

            while (current!=null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = prev.Next;
                    prev.Next=newNode;
                    Count++;
                    return;
                }
                prev = current;
                current=current.Next;
            }
            throw new Exception("The node could not be found in the linked list.");
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T item)
        {
            if (Head is null)
            {
                AddFirst(item);
                return;
            }
            var newNode = new SinglyLinkedListNode<T>(item);
            var current = Head;

            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next=newNode;
                    Count++;
                    return;
                }
                current = current.Next;
            }
            
            throw new Exception("The node could not be found in the linked list.");
        }
       
        public T RemoveFirst()
        {
            if (Head is null) throw new Exception("Linked list is empty!");
            T item = Head.Value;
            Head = Head.Next;
            Count--;
            return item;
        }

        public T RemoveLast()
        {
            if (Head is null) throw new Exception("Linked list is empty!");
            var current = Head;
            var prev = current;

            if(current.Next is null)
            {
                T item = current.Value;
                Head = null;
                Count--;
                return item;
            }

            while (current is not null)
            {
                if (current.Next is null)
                {
                    T item = current.Value;
                    prev.Next = null;
                    Count--;
                    return item;
                }
                prev = current;
                current = current.Next; 
            }

            throw new Exception();
        }

        public T Remove(SinglyLinkedListNode<T> node)
        {
            if (Head is null) throw new Exception("Linked list is empty!");
            if (Head.Value.Equals(node.Value)) return RemoveFirst();

            var current = Head;

            while (current is not null)
            {
                if (current.Next.Value.Equals(node.Value))
                {
                    T item = node.Value;
                    current.Next = current.Next.Next;
                    Count--;
                    return item;
                }
                current = current.Next;
            }
            throw new Exception("Node not found!");
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}