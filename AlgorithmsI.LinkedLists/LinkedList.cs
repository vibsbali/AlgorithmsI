using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsI.LinkedLists
{
    public class LinkedList<T> : ICollection<T>
    {
        private Node<T> Head { get; set; }
        private Node<T> Tail { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T value)
        {
            var node = new Node<T>(value);
            if (Head == null)
            {
                Head = node;
                Tail = Head;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }

            Count++;
        }

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var node = Head;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            var node = Head;
            while (node != null)
            {
                array[arrayIndex++] = node.Value;
                node = node.Next;
            }
        }

        public bool Remove(T item)
        {
            var node = Head;
            Node<T> previous = null;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    //We have found the node to be at the head
                    if (previous == null)
                    {
                        if (Head == Tail)
                        {
                            Clear();
                            return true; 
                        }
                        //else
                        Head = Head.Next;
                    }
                    else
                    {
                        //If we get to this stage it means that the previous is not null
                        if (node == Tail)
                        {
                            Tail = null;
                            Tail = previous;
                        }
                        else
                        {
                            previous.Next = node.Next;
                            node = null;
                        }
                    }
                    
                    Count --;
                    return true;
                }
                previous = node;
                node = node.Next;
            }

            return false;
        }

        public int Count { get; private set; }
        public bool IsReadOnly => true;
    }
}
