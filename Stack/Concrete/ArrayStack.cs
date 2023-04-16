using Stack.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Concrete
{
    public class ArrayStack<T> : IStack<T>
    {
        private List<T> _innerArray;

        private int _index => Count - 1;
        public int Count => _innerArray.Count;

        public ArrayStack()
        {
            _innerArray = new List<T>();
        }

        public ArrayStack(IEnumerable<T> values) : this()
        {
            foreach (var item in values)
            {
                Push(item);
            }
        }
        public T Peek()
        {
            return Count == 0 ? default(T) : _innerArray[_index];
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Empty Stack");
            }
            var temp = _innerArray[_index];
            _innerArray.RemoveAt(_index);
            return temp;
        }

        public void Push(T item)
        {
            _innerArray.Add(item);
        }
    }
}
