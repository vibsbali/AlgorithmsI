using System;
using System.Collections.Generic;

namespace AlgorithmsI.StacksAndQueues
{
    public class Deque<T>
    {
        private readonly LinkedList<T> backingStore = new LinkedList<T>();

        public void EnqueueFirst(T item)
        {
            backingStore.AddFirst(item);
        }

        public void EnqueueLast(T item)
        {
            backingStore.AddLast(item);
        }

        public T DequeueLast()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            var itemToReturn = backingStore.Last;
            backingStore.RemoveLast();
            return itemToReturn.Value;
        }


        public T DequeueFirst()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            var itemToReturn = backingStore.First;
            return itemToReturn.Value;
        }

        public T PeekFirst()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            var itemToReturn = backingStore.First;
            backingStore.RemoveFirst();
            return itemToReturn.Value;
        }

        public T PeekLast()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Deque is empty");
            }

            var itemToReturn = backingStore.Last;
            return itemToReturn.Value;
        }

        public int Count => backingStore.Count;
    }
}
