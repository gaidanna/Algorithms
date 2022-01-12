namespace CertificateTasks.Heap
{
    interface IHeap
    {
        int Size { get; set; }
        int[] Items { get; set; }

        int GetLeftChildIndex(int parentIndex);

        int GetRightChildIndex(int parentIndex);

        int GetParentIndex(int childIndex);

        int GetLeftChild(int index);

        int GetRightChild(int index);

        int GetParent(int childIndex);

        bool HasLeftChild(int parentIndex);

        bool HasRightChild(int parentIndex);

        bool HasParent(int childIndex);

        void EnsureExtraCapacity();

        int Peek();

        int Poll();

        void Add(int value);

        void HeapifyDown();

        void HeapifyUp();
    }
}
