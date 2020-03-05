using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LList2<T> : IList1<T> where T : IComparable<T>
    {
        public Node2<T> Root; //корневой элемент
        public int Count = 0;

        public LList2(T rootVal)
        {
            Root = new Node2<T>(rootVal);
            Count++;
        }
        public LList2() { }
        public LList2(T[] initialArray)
        {
            Root = new Node2<T>(initialArray[0]);
            Count++;
            for (int i = 1; i < initialArray.Length; i++)
            {
                Add(initialArray[i]);
            }
        }

        public T[] InsertStart(T val)//добавление в начало
        {
            Node2<T> n = new Node2<T>(val);
            Node2<T> tmp = Root;
            Root = n;
            Root.Next = tmp;
            tmp.Previous = Root;
            Root.Previous = null;
            Count++;
            return ConvertToArr(Root);
        }

        public T[] Add(T newItem)
        {
            if (newItem != null)
            {
                if (Root == null)
                {
                    Root = new Node2<T>(newItem);
                    Count++;
                }
                else
                {
                    Node2<T> end = GetLastNode();//получить ссылку на последний элемент
                    end.Next = new Node2<T>(newItem);
                    end.Next.Previous = end;
                    Count++;
                }
            }
            return ConvertToArr(Root);
        }

        public T[] Add(T[] newArr)
        {
            if (newArr != null)
            {
                for (int i = 0; i < newArr.Length; i++)
                {
                    Add(newArr[i]);
                }
            }
            return ConvertToArr(Root);
        }

        public T FindMax()
        {
            Node2<T> maxNode = Root;
            Node2<T> tmpNode = Root;

            while (tmpNode != null)//находим мин эл-т
            {
                if (maxNode.Value.CompareTo(tmpNode.Value) < 0)
                {
                    maxNode = tmpNode;
                }
                tmpNode = tmpNode.Next;
            }
            return maxNode.Value;
        }

        public T FindMin()
        {
            Node2<T> minNode = Root;
            Node2<T> tmpNode = Root;

            while (tmpNode != null)//находим мин эл-т
            {
                if (minNode.Value.CompareTo(tmpNode.Value) > 0)
                {
                    minNode = tmpNode;
                }
                tmpNode = tmpNode.Next;
            }
            return minNode.Value;
        }

        public Node2<T> GetTActNode(int index) //поиск текущего элемента
        {
            if (index != null)
            {
                Node2<T> tmpNode = this.Root; //ук-ль на начало списка

                for (int i = 0; i < index; i++)
                {
                    tmpNode = tmpNode.Next;
                }

                return tmpNode;
            }
            else return null;
        }

        public T[] AddIndex(T newItem, int index)
        {
            if (index == 0)
            {
                InsertStart(newItem);
            }
            else
            {
                Node2<T> t = GetTActNode(index - 1);
                Node2<T> n = new Node2<T>(newItem);

                Node2<T> tmp = t.Next;
                t.Next = n;
                n.Previous = t;
                n.Next = tmp;
                tmp.Previous = n;
                Count++;
            }

            return ConvertToArr(Root);
        }

        public Node2<T> GetLastNode() //поиск последнего элемента
        {
            Node2<T> tmpNode = this.Root; //ук-ль на начало списка

            while (tmpNode.Next != null)//проход по списку
            {
                tmpNode = tmpNode.Next; //ук-ль на след эл-т
            }

            return tmpNode;
        }

        public T[] ConvertToArr(Node2<T> element)
        {
            if (element == null)
                return null;
            Node2<T> tmpNode = element; //ук-ль на начало списка
            Node2<T> tmp = element;
            int count = 0;

            while (tmp != null)//проход по списку
            {
                tmp = tmp.Next; //ук-ль на след эл-т
                count++;
            }

            T[] array = new T[count];

            for (int i = 0; i < count; i++)
            {
                array[i] = tmpNode.Value;
                tmpNode = tmpNode.Next;
            }

            return array;
        }

        public void Print()
        {
            Node2<T> tmpNode = Root;

            while (tmpNode != null)
            {
                Console.Write(tmpNode.Value + " ");
                tmpNode = tmpNode.Next;
            }
            Console.WriteLine();
        }

        public T[] Reverse()
        {
            Node2<T> current = Root;
            Node2<T> end = GetLastNode();
            Node2<T> next = null;

            while (current != null)
            {
                Node2<T> tmp = current.Next;
                current.Next = next;
                next = current;
                current.Previous = tmp;
                current = tmp;
            }

            Root = next;

            return ConvertToArr(Root);
        }

        public T[] Half()
        {
            int count = 0;
            Node2<T> tmpNode = Root; //ук-ль на начало списка

            while (tmpNode != null)//проход по списку
            {
                tmpNode = tmpNode.Next;//ук-ль на след эл-т
                count++;//считает количество элементов
            }

            switch (count % 2)
            {
                case 0:
                    HalfEven(count);
                    break;
                case 1:
                    HalfUneven(count);
                    break;
            }

            return ConvertToArr(Root);
        }

        public void HalfEven(int count)
        {
            Node2<T> current = Root; //ук-ль на начало списка

            int half = count / 2;

            for (int i = 0; i < half - 1; i++)
            {
                current = current.Next;
            }

            Node2<T> tmp = current.Next;
            tmp.Previous = null;
            current.Next = null;
            current = tmp;

            while (current.Next != null)//проход по списку
            {
                current = current.Next;//ук-ль на след эл-т                
            }

            current.Next = Root;
            Root.Previous = current;
            Root = tmp;
        }

        public void HalfUneven(int count)
        {
            Node2<T> current = Root; //ук-ль на начало списка
            Node2<T> tmp1 = Root;
            Node2<T> end = GetLastNode();
            int half = count / 2;

            for (int i = 0; i < half; i++)
            {
                current = current.Next;
            }

            current.Next.Previous = null;
            Root = current.Next;
            current.Previous = end;
            end.Next = current;
            current.Next = tmp1;
            tmp1.Previous = current;

            for (int i = 0; i < count; i++)
            {
                current = current.Next;
            }

            current.Next = null;
        }

        public T[] Remove(int index)
        {
            if (index < Count)
            {
                Node2<T> t = GetTActNode(index);
                if (t == GetLastNode())
                {
                    t.Previous.Next = null;
                    Count--;
                }
                else if (t == Root)
                {
                    Root = t.Next;
                    Root.Previous = null;
                    Count--;
                }
                else
                {
                    t.Previous.Next = t.Next;
                    //Node2<T> tmp = t.Next.Previous;
                    t.Next.Previous = t.Previous;
                    //t.Next.Next.Previous = tmp;
                    Count--;
                }
            }
            return ConvertToArr(Root);
        }

        public T[] SortToDecr()//по убыванию
        {
            Node2<T> current = Root; //ук-ль на начало списка
                                     //опт решение 4 вложенных while
            int count = 0;

            while (current != null)//проход по списку
            {
                current = current.Next;//ук-ль на след эл-т
                count++;//считает количество элементов
            }

            for (int i = 0; i < count; i++)
            {
                current = Root;

                for (int j = 0; j < count - i - 1; j++)
                {
                    if (current != null)
                    {
                        if (current.Value.CompareTo(current.Next.Value) < 0)
                        {
                            if (current == Root)
                            {
                                Node2<T> tmp = current.Next;
                                current.Next = tmp.Next;
                                current.Next.Previous = current;
                                current.Previous = tmp;
                                tmp.Next = current;
                                tmp.Previous = null;
                                Root = tmp;
                            }
                            else
                            {
                                Node2<T> tmp1 = current.Next;
                                Node2<T> tmp2 = current.Previous;
                                current.Next = tmp1.Next;
                                if (tmp1.Next != null)
                                {
                                    current.Previous = tmp1.Next.Previous;
                                    current.Next.Previous = current;
                                }
                                else if (tmp1.Next == null)
                                {
                                    current.Previous = tmp1;
                                }
                                current.Previous.Next = current;
                                current.Previous.Previous = tmp2;
                                tmp2.Next = current.Previous;

                            }
                            if (current.Next == null)
                                break;
                        }
                        else
                            current = current.Next;
                    }
                }
            }
            return ConvertToArr(Root);
        }

        public T[] SortToIncr()//по возрастанию
        {
            Node2<T> current = Root.Next; //ук-ль на начало списка
                                          //опт решение 4 вложенных while

            while (current != null)//находим мин эл-т
            {
                while (current != Root && current.Value.CompareTo(current.Previous.Value) < 0)
                {
                    if (current.Previous == Root)
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        Root.Previous = current;
                        current.Next = Root;
                        current.Previous = null;
                        Root = current;
                    }
                    else
                    {
                        Node2<T> tmp1 = current.Previous;
                        Node2<T> tmp2 = current.Next;
                        Node2<T> tmp3 = tmp1.Previous;

                        tmp1.Next = tmp2;
                        if (tmp2 != null)
                        {
                            tmp2.Previous = tmp1;
                        }

                        current.Previous = tmp1.Previous;
                        current.Next = current.Previous.Next;
                        current.Previous.Next = current;
                        tmp1.Previous = current;
                    }
                }
                current = current.Next;
            }
            return ConvertToArr(Root);
        }
    }
}
