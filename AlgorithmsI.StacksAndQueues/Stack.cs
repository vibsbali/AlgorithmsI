using System;
using System.Collections.Generic;

namespace AlgorithmsI.StacksAndQueues
{
    public class Stack<T>
    {
        private readonly LinkedList<T> items = new LinkedList<T>();

        public void Push(T item)
        {
            items.AddFirst(item);
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Empty Stack");
            }

            var item = items.First;
            items.RemoveFirst();

            return item.Value;
        }

        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("The statck is empty");
            }

            return items.First.Value;
        }

        public int Count => items.Count;
    }
}
