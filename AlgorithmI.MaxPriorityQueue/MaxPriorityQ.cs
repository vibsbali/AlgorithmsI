using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmI.MaxPriorityQueue
{
    public class MaxPriorityQ<T> : ICollection<T>
        where T : IComparable<T>
    {
        private readonly T[] BackingArray;

        public MaxPriorityQ(int size)
        {
            //Size + 1 because we do not add anyting to element 0
            BackingArray = new T[size + 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            BackingArray[Count + 1] = item;
            Swim(Count + 1);
            Count++;
        }

        private void Swim(int k)
        {
            if (k == 1)
            {
                return;
            }

            var j = k / 2;
            if (BackingArray[j].CompareTo(BackingArray[k]) < 0)
            {
                Swap(j, k);
                k = j;
            }
            else if (BackingArray[j + 1].CompareTo(BackingArray[k]) < 0)
            {
                Swap(j + 1, k);
                k = j + 1;
            }
            else
            {
                return;
            }

            Swim(k);
        }

        public T RemoveMax()
        {
            //The max item is going to be in element 1
            var max = BackingArray[1];
            Sink(1);
            Count--;

            return max;
        }

        private void Sink(int k)
        {
            if (k * 2 >= Count)
            {
                if (k != Count)
                {
                    Swap(k, Count);
                }

                return;
            }

            int j = 2 * k;
            var max = GreaterThan(j, j + 1);
            if (max == j)
            {
                Swap(k, j);
            }
            else
            {
                Swap(k, j + 1);
            }
            

            Sink(max);
        }

        private int GreaterThan(int k, int j)
        {
            return BackingArray[k].CompareTo(BackingArray[j]) > 0 ? k : j;
        }

        private void Swap(int j, int i)
        {
            var temp = BackingArray[j];
            BackingArray[j] = BackingArray[i];
            BackingArray[i] = temp;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; }
    }
}
