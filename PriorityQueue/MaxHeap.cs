using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class MaxHeap<T> : BHeap<T>, IEnumerable<T>
        where T : IComparable
    {
        public MaxHeap(int _size = 128) : base(_size) { }
        public MaxHeap(IEnumerable<T> values) : base(values) { }
        public override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) > 0) 
                    smallerIndex = GetRightChildIndex(index);
                if (Array.GetItem(smallerIndex).CompareTo(Array.GetItem(index)) < 0) break;
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        public override void HeapifyUp()
        {
            var index = position - 1;
            while(!IsRoot(index) && Array.GetItem(index).CompareTo(GetParent(index)) > 0)
            {
                var parentIndex = GetParentIndex(index);
                Swap(parentIndex, index);
                index = parentIndex;
            }
        }
    }
}
