using System.Collections;

namespace Array
{
    public class Array : IEnumerable
    {
        private Object[] _InnerArray;
        private int index = 0;
        public int Count => index;
        public int Capacity => _InnerArray.Length;
        public Array()
        {
            _InnerArray = new Object[4];
        }

        public Array(params Object[] items)
        {
            var newArray = new Object[items.Length];
            System.Array.Copy(items, newArray, items.Length);
            _InnerArray = newArray;
            index = items.Count();
        }

        public void Add(Object item)
        {
            if (index==Capacity)
            {
                DoubleArray(_InnerArray);
            }
            _InnerArray[index] = item;
            index++;
        }

        private void DoubleArray(object[] innerArray)
        {
            var newArray = new Object[innerArray.Length * 2];
            System.Array.Copy(innerArray, newArray, innerArray.Length);
            _InnerArray = newArray;
        }

        public Object GetItem(int position)
        {
            if (position < 0 || position >= _InnerArray.Length) throw new IndexOutOfRangeException();
            return _InnerArray[position];
        }

        public void SetItem(int position, Object item)
        {
            if (position < 0 || position >= _InnerArray.Length) throw new IndexOutOfRangeException();
            _InnerArray[position] = item;
        }

        public int Find(Object item)
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

        public Object[] Copy(int v1, int v2)
        {
            var newArray = new Object[v2];
            int j = 0;

            for (int i = v1; i < v2; i++)
            {
                newArray[j] = GetItem(i);
                j++;
            }
            return newArray;
        }

        public Object RemoveItem(int position)
        {
            var item = GetItem(position);
            SetItem(position, null);

            for (int i = 0; i < Count-1; i++)
            {
                Swap(i, i + 1);
            }
            index--;

            if (index == Capacity/2)
            {
                var newArray = new Object[_InnerArray.Length / 2];
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

        public IEnumerator GetEnumerator()
        {
            return _InnerArray.GetEnumerator();
        }
    }
}