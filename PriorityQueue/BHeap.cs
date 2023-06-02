using Array;
using System.Collections;

namespace PriorityQueue
{
    public abstract class BHeap<T> : IEnumerable<T> where T : IComparable
    {
        public Array<T> Array { get; private set; } = new Array<T>();

        protected int position;

        public int Count { get; private set; }

        public BHeap(int _size = 128)
        {
            Count = 0;
            Array = new Array<T>(_size);
            position = 0;
        }

        public BHeap(IEnumerable<T> values) : this(values.ToArray().Length)
        {
            foreach (var value in values) Add(value);
        }

        public int GetLeftChildIndex(int i) => (2 * i) + 1;
        public int GetRightChildIndex(int i) => (2 * i) + 2;
        public int GetParentIndex(int i) => (i-1) / 2;
        protected bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        protected bool HasRightChild(int i) => GetRightChildIndex(i) < position;
        protected bool IsRoot(int i) => i == 0;
        protected T GetLeftChild(int i) => Array.GetItem(GetLeftChildIndex(i));
        protected T GetRightChild(int i) => Array.GetItem(GetRightChildIndex(i));
        protected T GetParent(int i) => Array.GetItem(GetParentIndex(i));
        public bool IsEmpty() => position == 0;

        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Empty Heap");
            return Array.GetItem(0);
        }

        public void Swap(int v1, int v2)
        {
            var temp = Array.GetItem(v1);
            Array.SetItem(Array.GetItem(v2), v1);
            Array.SetItem(temp, v2);
        }

        public void Add(T item)
        {
            Array.SetItem(item, position);
            Array.index++;
            position++;
            Count++;
            HeapifyUp();
        }

        public T DeleteMinMax()
        {
            if (position == 0) throw new IndexOutOfRangeException("Empty Heap");
            var temp = Array.GetItem(0);
            Array.SetItem(Array.GetItem(position - 1), 0);
            Array.SetItem(default, (position - 1));
            Array.index--;
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        public abstract void HeapifyUp();
        public abstract void HeapifyDown();
        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}