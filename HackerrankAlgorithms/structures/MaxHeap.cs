using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.structures
{
    public class MaxHeap : IHeap
    {
        public static int capacity = 10;
        public int Size { get; set; } = 0;

        public int[] Items { get; set; } = new int[capacity];

        public int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        public int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public int GetParentIndex(int childIndex)
        {
            if (childIndex - 1 < 0)
            {
                return -1;
            }
            return (childIndex - 1) / 2;
        }

        public int GetLeftChild(int index)
        {
            return Items[GetLeftChildIndex(index)];
        }

        public int GetRightChild(int index)
        {
            return Items[GetRightChildIndex(index)];
        }

        public int GetParent(int childIndex)
        {
            return Items[GetParentIndex(childIndex)];
        }

        public bool HasLeftChild(int parentIndex)
        {
            var index = GetLeftChildIndex(parentIndex);

            return index < Size;
        }

        public bool HasRightChild(int parentIndex)
        {
            var index = GetRightChildIndex(parentIndex);

            return index < Size;
        }

        public bool HasParent(int childIndex)
        {
            var index = GetParentIndex(childIndex);
            return index >= 0;
        }

        public void EnsureExtraCapacity()
        {
            if (Size == capacity)
            {
                int[] itemsUpdated = Items;
                Array.Resize(ref itemsUpdated, capacity * 2);
                Items = itemsUpdated;
                capacity *= 2;
            }
        }

        public int Peek()
        {
            if (Size <= 0)
            {
                throw new InvalidOperationException();
            }
            return Items[0];
        }

        public int Poll()
        {
            if (Size <= 0)
            {
                throw new InvalidOperationException();
            }
            int rootValue = Items[0];
            Items[0] = Items[Size - 1];
            Items[Size - 1] = 0;
            Size--;
            HeapifyDown();
            return rootValue;
        }

        public void Add(int value)
        {
            EnsureExtraCapacity();
            Items[Size] = value;
            Size++;
            HeapifyUp();
        }

        public void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var biggerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index) > GetLeftChild(index))
                {
                    biggerIndex = GetRightChildIndex(index);
                }

                if (Items[biggerIndex] < Items[index])
                {
                    break;
                }

                SwapItems(biggerIndex, index);
                index = biggerIndex;
            }
        }

        public void HeapifyUp()
        {
            var index = Size - 1;
            while (HasParent(index) && Items[index] > GetParent(index))
            {
                var parentIndex = GetParentIndex(index);
                SwapItems(parentIndex, index);
                index = parentIndex;
            }
        }
        
        private void SwapItems(int item1Index, int item2Index)
        {
            var temp = Items[item1Index];
            Items[item1Index] = Items[item2Index];
            Items[item2Index] = temp;
        }
    }
}
