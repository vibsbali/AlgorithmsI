using System;

namespace AlgorithmsI.StacksAndQueues
{
    public class DequeWithArray<T>
    {
        private T[] backingArray;
        private int head;
        private int tail;

        public int Count { get; private set; }

        public DequeWithArray() : this(4)
        {

        }

        public DequeWithArray(int size)
        {
            backingArray = new T[size];
        }

        public void EnqueueLast(T item)
        {
            if (head == backingArray.Length && Count < backingArray.Length)
            {
                head = 0;
            }
            else if (Count == backingArray.Length)
            {
                ResizeUp();
            }

            backingArray[head++] = item;
            Count++;
        }

        public void EnqueueFirst(T item)
        {
            //bit complicated best to use linked list!
        }


        private void ResizeUp()
        {
            var tempArray = new T[Count * 2];
            if (head > tail) //i.e. head is not wrapped
            {
                Array.Copy(backingArray, 0, tempArray, 0, Count);
                backingArray = tempArray;
            }
            else
            {
                Array.Copy(backingArray, tail, tempArray, 0, Count - tail);
                Array.Copy(backingArray, 0, tempArray, Count - tail, head);
                backingArray = tempArray;
                tail = 0;
                head = Count;
            }
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot call dequeue on an empty deque");
            }

            var item = backingArray[tail++];

            Count--;
            return item;
        }
    }
}
