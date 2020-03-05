using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class Node2<T>
    {
        public T Value;//элемент массива
        public Node2<T> Previous;
        public Node2<T> Next;//ссылка на след узел

        public Node2(T val)
        {
            this.Value = val;
            Next = null;
            Previous = null;
        }
    }
}
