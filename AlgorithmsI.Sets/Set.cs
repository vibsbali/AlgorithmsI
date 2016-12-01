using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsI.Sets
{
    public class Set<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private List<T> items;

        public Set()
        {
            items = new List<T>();
        }

        public Set(IEnumerable<T> itemsToAdd)
        {
            items = new List<T>(itemsToAdd);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (items.Contains(item))
            {
                throw new InvalidOperationException("Cannot insert same item");
            }

            items.Add(item);
            Count++;
        }

        public void AddRange(IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                Add(item);
                Count++;
            }
        }

        public Set<T> Union(IEnumerable<T> other)
        {
            var setToReturn = new Set<T>(other);

            foreach (var item in items)
            {
                if (!setToReturn.Contains(item))
                {
                    setToReturn.Add(item);
                }
            }

            return setToReturn;
        }

        public Set<T> Intersect(IEnumerable<T> other)
        {
            var setToReturn = new Set<T>();

            foreach (var item in other)
            {
                if (items.Contains(item))
                {
                    setToReturn.Add(item);
                }
            }

            return setToReturn;
        }

        public Set<T> Except(IEnumerable<T> other)
        {
            var setToReturn = new Set<T>(items);

            foreach (var item in other)
            {
                if (setToReturn.Contains(item))
                {
                    setToReturn.Remove(item);
                }
            }

            return setToReturn;
        }

        public Set<T> SymmetricDifference(IEnumerable<T> other)
        {
            var setToReturn = new Set<T>(other);

            var union = setToReturn.Union(items);
            var intersection = setToReturn.Intersect(items);

            return union.Except(intersection);
        }

        public void Clear()
        {
            items = new List<T>();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public bool Remove(T item)
        {
            return items.Remove(item);
        }

        public int Count { get; private set; }

    }
}
