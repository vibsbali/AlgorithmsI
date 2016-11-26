using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsI.LinkedLists
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }
        public DoublyLinkedNode<T> Tail { get; private set; }

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
            var node = new DoublyLinkedNode<T>(value);
            if (Head == null)
            {
                Head = Tail = node;
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
            DoublyLinkedNode<T>  previous = null;
            while (node != null)
            {
                if (node.Value.Equals(item))
                {
                    //Is it head
                    if (previous == null)
                    {
                        var nextNode = Head.Next;
                        Head.Next = null;
                        nextNode.Previous = null;
                        Head = nextNode;
                    }
                    else
                    {
                        //Is it tail
                        if (node.Next == null)
                        {
                            Tail = null;
                            previous.Next = null;
                            Tail = previous;
                        }
                        else
                        {
                            previous.Next = node.Next;
                            node.Next.Previous = previous;
                            node = null;
                        }
                        Count--;
                        return true;
                    }
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
