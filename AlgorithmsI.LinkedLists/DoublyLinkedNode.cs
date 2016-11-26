namespace AlgorithmsI.LinkedLists
{
    public class DoublyLinkedNode<T>
    {
        public T Value { get; private set; }

        public DoublyLinkedNode(T value)
        {
            Value = value;
        }

        public DoublyLinkedNode<T> Next { get; set; }
        public DoublyLinkedNode<T> Previous { get; set; }
    }
}
