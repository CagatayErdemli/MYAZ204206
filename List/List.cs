using System.Collections;

namespace List
{
    public class List<T> : IEnumerable<T>
    {
        private T[] _list;
        private int _index;
        public int Capacity => _list.Length;
        public int Count => _index;

        public List()
        {
            _list = new T[4];
        }

        public void Add(T item)
        {
            if (_index == _list.Length) DoubleList(_list);
            _list[_index++] = item;
        }

        private void DoubleList(T[] list)
        {
            var newList = new T[list.Length*2];
            System.Array.Copy(list, newList, list.Length);
            _list = newList;
        }

        public void AddRange(IEnumerable<T> values)
        {
            foreach (var item in values) Add(item);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < _list.Length; i++)
            {
                if (_list[i].Equals(item))
                {
                    _list[i] = default;
                    for (int j = i; j < _list.Length-1; j++) Swap(j, j + 1);
                    _index--;

                    if (_index == _list.Length/2) HalfList(_list);
                    return true;
                }
            }

            return false;
        }

        private void HalfList(T[] list)
        {
            var newList = new T[_list.Length / 2];
            System.Array.Copy(list, newList, newList.Length);
            _list = newList;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= _list.Length) return false;
            _list[index] = default;
            for (int i = index; i < _list.Length-1; i++) Swap(i, i + 1);
            return true;
        }
        private void Swap(int i, int v)
        {
            var temp = _list[i];
            _list[i] = _list[v];
            _list[v] = temp;
        }
        public T[] InterSect(IEnumerable<T> values)
        {
            T[] newList = new T[_list.Length];
            newList = values.Intersect(_list).ToArray();
            return newList;
        }

        public T[] Union(IEnumerable<T> values)
        {
            //T[] newList = new T[_list.Length + values.Count()];
            //newList = _list.Union(values).ToArray();
            //return newList;

            T[] newList = new T[_list.Length + values.Count()];
            int i = 0;
            foreach (T item in _list.Union(values).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }

        public T[] Except(IEnumerable<T> values)
        {
            T[] newList = new T[_list.Length];
            newList = _list.Except(values).ToArray();
            return newList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.Take(_index).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}