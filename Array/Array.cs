using System.Collections;

namespace Array
{
    public class Array<T> : IEnumerable<T>
    {
        private T[] _InnerArray;
        public int index = 0;
        public int Count => index;
        public int Capacity => _InnerArray.Length;
        public Array()
        {
            _InnerArray = new T[4];
        }

        public Array(params T[] items)
        {
            var newArray = new T[items.Length];
            System.Array.Copy(items, newArray, items.Length);
            _InnerArray = newArray;
            index = items.Count();
        }

        public Array(int _size)
        {
            _InnerArray = new T[_size];
        }

        public void Add(T item)
        {
            if (index==Capacity)
            {
                DoubleArray(_InnerArray);
            }
            _InnerArray[index] = item;
            index++;
        }

        private void DoubleArray(T[] innerArray)
        {
            var newArray = new T[innerArray.Length * 2];
            System.Array.Copy(innerArray, newArray, innerArray.Length);
            _InnerArray = newArray;
        }

        public T GetItem(int position)
        {
            if (position < 0 || position >= _InnerArray.Length) throw new IndexOutOfRangeException();
            return _InnerArray[position];
        }

        public void SetItem(T item, int position)
        {
            if (position < 0 || position >= _InnerArray.Length) throw new IndexOutOfRangeException();
            if (item == null) throw new ArgumentNullException();
            _InnerArray[position] = item;
        }

        public int Find(T item)
        {
            for (int i = 0; i < _InnerArray.Length; i++)
            {
                if (item.Equals(_InnerArray[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public T[] Copy(int v1, int v2)
        {
            var newArray = new T[v2];
            int j = 0;

            for (int i = v1; i < v2; i++)
            {
                newArray[j] = GetItem(i);
                j++;
            }
            return newArray;
        }

        public T RemoveItem(int position)
        {
            var item = GetItem(position);
            SetItem(default,position);

            for (int i = 0; i < Count-1; i++)
            {
                Swap(i, i + 1);
            }
            index--;

            if (index == Capacity/2)
            {
                var newArray = new T[_InnerArray.Length / 2];
                System.Array.Copy(_InnerArray, newArray, newArray.Length);
                _InnerArray = newArray;
            }
            return item;
        }

        public void Swap(int i, int v)
        {
            var temp = _InnerArray[i];
            _InnerArray[i] = _InnerArray[v];
            _InnerArray[v] = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _InnerArray.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}