using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class Node<T>
    {
        public T Value;//элемент массива
        public Node<T> Next;//ссылка на след узел

        public Node(T val)
        {
            this.Value = val;
            Next = null;
        }
    }
}
