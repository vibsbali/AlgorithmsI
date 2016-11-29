using System;
using System.Collections.Generic;

namespace AlgorithmsI.StacksAndQueues
{
    public class Queue<T>
    {
        private readonly LinkedList<T> backingStore = new LinkedList<T>();

        public void Enqueue(T item)
        {
            backingStore.AddLast(item);
        }

        public T Dequeue()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var item = backingStore.First;
            backingStore.RemoveFirst();

            return item.Value;
        }

        public T Peek()
        {
            if (backingStore.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return backingStore.First.Value;
        }

        public int Count => backingStore.Count;
    }
}
