using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Contract
{
    public interface IQueue<T>
    {
        int Count { get; }
        void Enqueue(T item);
        T Dequeue();
        T Peek();
    }
}
