﻿using System.Threading;

namespace AlgorithmsI.LinkedLists
{
    public class Node<T>
    {
        public T Value { get; private set; }

        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next { get; set; }
    }
}
