using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class AList0<T> : IList1<T> where T : IComparable<T>
    {
        private T[] newArr;

        public AList0(T[] array)
        {
            newArr = array;
        }

        public AList0() { }
        public T[] Half()
        {
            T[] arr = new T[newArr.Length];
            if ((newArr.Length % 2) != 0)
            {
                for (int i = 0; i < (newArr.Length / 2); i++)
                {
                    T tmp = newArr[i];
                    arr[i] = newArr[i + newArr.Length / 2 + 1];
                    arr[i + newArr.Length / 2 + 1] = tmp;
                }
                arr[newArr.Length / 2] = newArr[newArr.Length / 2];
            }
            else
            {
                for (int i = 0; i < (newArr.Length / 2); i++)
                {
                    T tmp = newArr[i];
                    arr[i] = newArr[i + newArr.Length / 2];
                    arr[i + newArr.Length / 2] = tmp;
                }
            }
            this.newArr = arr;
            return this.newArr;
        }        

        public T[] Add(T newItem)
        {
            if (newItem != null)
            {
                if (this.newArr == null)
                    this.newArr = new T[] { newItem };
                else
                {
                    T[] arr = new T[this.newArr.Length + 1];
                    for (int i = 0; i < newArr.Length; i++)
                    {
                        arr[i] = newArr[i];
                    }
                    arr[arr.Length - 1] = newItem;
                    this.newArr = arr;
                }
            }
            
            return this.newArr;
        }

        public T[] Add(T[] _array)
        {
            if (_array != null)
            {
                if (this.newArr == null)
                    this.newArr = _array;
                else
                {
                    T[] arr = new T[this.newArr.Length + _array.Length];
                    for (int i = 0; i < newArr.Length; i++)
                    {
                        arr[i] = newArr[i];
                    }
                    for (int i = 0; i < _array.Length; i++)
                    {
                        arr[i + newArr.Length] = _array[i];
                    }

                    this.newArr = arr;
                }
            }

            return this.newArr;
        }

        public T[] AddIndex(T newItem, int index)
        {
            if (index != null || newItem != null)
            {
                T[] arr = new T[this.newArr.Length + 1];
                int j = 0;
            
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i == index)
                    {
                        j = 1;
                        arr[i] = newItem;
                    }
                    else
                    {
                        arr[i] = this.newArr[i - j];
                    }
                }
                this.newArr = arr;
            }
            
            return this.newArr;
        }

        public T FindMax()
        {            
            T max = newArr[0];
            
            for (int i = 1; i < newArr.Length; i++)
            {                
                if (max.CompareTo(newArr[i]) < 0)
                {
                    max = newArr[i];
                }
            }
            return max;
        }

        public T FindMin()
        {            
            T min = newArr[0];

            for (int i = 1; i < newArr.Length; i++)
            {
                if (min.CompareTo(newArr[i]) > 0)
                {
                    min = newArr[i];
                }                
            }
            return min;
        }

        public T[] Mix()
        {
            T[] arr = this.newArr;            
            Random rnd = new Random();

            for (int i = 0; i < newArr.Length; i++)
            {
                int r = rnd.Next(newArr.Length);
                T tmp = arr[i];
                arr[i] = arr[r];
                arr[r] = tmp;
            }

            this.newArr = arr;
            return this.newArr;
        }

        public T[] Remove(int index)
        {
            if (index < newArr.Length && index != null)
            {
                T[] arr = new T[newArr.Length - 1];
                int j = 0;

                for (int i = 0; i < newArr.Length; i++)
                {
                    if (i != index)
                    {
                        arr[j] = newArr[i];
                        j++;
                    }
                }

                this.newArr = arr;
            }
            return this.newArr;
        }

        public T[] Reverse()
        {
            T[] arr = new T[newArr.Length];
            for (int i = 0; i < (newArr.Length / 2); i++)
            {
                T tmp = newArr[i];
                arr[i] = newArr[newArr.Length - 1 - i];
                arr[newArr.Length - 1 - i] = tmp;
            }

            this.newArr = arr;
            return this.newArr;
        }

        public T[] SortToDecr()//по убыванию
        {
            T tmp;
            for (int i = 0; i < newArr.Length - 1; i++)
            {
                for (int j = 0; j < newArr.Length - i - 1; j++)
                {
                    if (newArr[j + 1].CompareTo(newArr[j]) > 0)
                    {

                        tmp = newArr[j + 1];
                        newArr[j + 1] = newArr[j];
                        newArr[j] = tmp;
                    }
                }
            }

            return this.newArr;
        }

        public T[] SortToIncr()//по возрастанию
        {
            for (int i = 0; i < newArr.Length - 1; i++)
            {
                int min = i;
                T tmp;

                for (int j = i; j < newArr.Length; j++)
                {
                    if (newArr[min].CompareTo(newArr[j]) > 0)
                    {
                        min = j;
                    }
                }
                tmp = newArr[i];
                newArr[i] = newArr[min];
                newArr[min] = tmp;
            }

            return this.newArr;
        }

        public void Print()
        {
            for (int i = 0; i < newArr.Length; i++)
            {
                Console.Write(newArr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
