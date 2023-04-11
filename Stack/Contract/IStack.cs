using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Contract
{
    public interface IStack<T>
    {
        int Count { get; }
        void Push(T item);
        T Pop();
        T Peek();
    }
}
