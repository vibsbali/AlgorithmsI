using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsI.ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        //private variable to hold the initial length of the backing array in case we need to resize it when client calls Clear()!
        private readonly int initialLength;

        public int Count { get; private set; }
        public bool IsReadOnly => false;

        private T[] items;

        public ArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException("length");
            }

            initialLength = length;
            items = new T[length];
        }

        public ArrayList() : this(4)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Add item to last
        public void Add(T item)
        {
            if (Count == items.Length)
            {
                ResizeUp();
            }
            items[Count] = item;
            Count++;
        }

        private void ResizeUp()
        {
            var tempArray = new T[Count * 2];
            Array.Copy(items, tempArray, Count);
            items = tempArray;
        }

        private void ResizeDown()
        {
            var tempArray = new T[Count * 3 / 2]; //75% of the initial array size
            Array.Copy(items, tempArray, Count);
            items = tempArray;
        }

        public void Clear()
        {
            items = new T[initialLength];
        }

        public bool Contains(T item)
        {
            var isFound = IndexOf(item) != -1;
            return isFound;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        //There cannot be any gaps
        public void Insert(int index, T item)
        {
            if (index > Count)
            {
                throw new InvalidOperationException();
            }

            //else shift the array
            if (items.Length == Count)
            {
                ResizeUp();
            }
            Array.Copy(items, index, items, index + 1, Count - index);
            items[index] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (index > Count)
            {
                throw new InvalidOperationException();
            }

            //is the item the last item
            if (index == Count - 1)
            {
                items[index] = default(T);
            }
            else //otherwise we need to shift the array
            {
                Array.Copy(items, index + 1, items, index, Count - 2);
            }
            Count--;
            if (items.Length == Count / 2)
            {
                ResizeDown();
            }
        }



        public T this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return items[index];
                }

                throw new IndexOutOfRangeException();
            }

            set
            {
                if (index < Count)
                {
                    items[index] = value;
                }
            }
        }
    }
}
