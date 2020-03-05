using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public interface IList1<T> where T : IComparable<T>
    {
        T[] Add(T newItem);
        T[] Add(T[] _array);
        T[] AddIndex(T newItem, int index);
        T[] Remove(int index);
        T[] Reverse();
        T[] SortToIncr();
        T[] SortToDecr();
        T FindMin();
        T FindMax();
        T[] Half();
    }
}
