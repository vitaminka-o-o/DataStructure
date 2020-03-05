using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LList1<T> : IList1<T> where T : IComparable<T>
    {
        public Node<T> Root = null; //корневой элемент
        private int Count = 0;

        public LList1(T rootVal) //конструктор
        {
            Root = new Node<T>(rootVal);
            Count++;
        }
        public LList1() { }

        public LList1(T[] initialArray) //конструктор
        {
            Root = new Node<T>(initialArray[0]);
            Count++;
            for (int i = 1; i < initialArray.Length; i++)
            {
                Add(initialArray[i]);
            }
        }

        public Node<T> GetLastNode() //поиск последнего элемента
        {
            Node<T> tmpNode = this.Root; //ук-ль на начало списка
            while (tmpNode.Next != null)//проход по списку
            {
                tmpNode = tmpNode.Next; //ук-ль на след эл-т
            }
            return tmpNode;
        }

        public T[] InsertStart(T val) //добавление в начало
        {
            Node<T> n = new Node<T>(val);
            Node<T> tmp = Root;
            Root = n;
            Root.Next = tmp;
            Count++;
            return ConvertToArr(Root);
        }

        public T[] ConvertToArr(Node<T> element) //преобразование в массив
        {
            if (element == null)
                return null;
            Node<T> tmpNode = element; //ук-ль на начало списка
            Node<T> tmp = element;
            int count = 0;
            while (tmp != null)//проход по списку
            {
                tmp = tmp.Next; //ук-ль на след эл-т
                count++;
            }
            T[] array = new T[count];
            //tmpNode = this.Root;
            for (int i = 0; i < count; i++)
            {
                array[i] = tmpNode.Value;
                tmpNode = tmpNode.Next;
            }
            return array;
        }

        public Node<T> GetTActNode(int index) //поиск тукущего элемента
        {
            Node<T> tmpNode = this.Root; //ук-ль на начало списка

            for (int i = 0; i < index; i++)
            {
                tmpNode = tmpNode.Next;
            }
            return tmpNode;
        }

        public T[] Add(T newItem) //добавление в конец
        {
            if (newItem != null)
            {
                if (Root == null)
                {
                    Root = new Node<T>(newItem);
                    Count++;
                }
                else
                {
                    Node<T> end = GetLastNode();//получить ссылку на последний элемент
                    end.Next = new Node<T>(newItem);
                    Count++;
                }
            }

            return ConvertToArr(Root);
        }

        public T[] Add(T[] newArr) //добавление в конец
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

        public T[] AddIndex(T newItem, int index) //добавление по индексу
        {

            if (index == 0)
            {
                InsertStart(newItem);
            }
            else
            {
                Node<T> t = GetTActNode(index - 1);
                Node<T> n = new Node<T>(newItem);

                Node<T> tmp = t.Next;
                t.Next = n;
                n.Next = tmp;
                Count++;
            }

            return ConvertToArr(Root);
        }

        public T FindMax()
        {
            Node<T> maxNode = Root;
            Node<T> tmpNode = Root;

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
            Node<T> minNode = Root;
            Node<T> tmpNode = Root;

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

        public T[] Half() //поменять первую и вторую половины списка местами
        {
            int count = 0;
            Node<T> tmpNode = Root; //ук-ль на начало списка

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
            Node<T> tmpNode = Root;
            tmpNode = Root;
            int half = count / 2;

            for (int i = 0; i < half - 1; i++)
            {
                tmpNode = tmpNode.Next;
            }

            Node<T> tmp = tmpNode.Next;
            tmpNode.Next = null;
            tmpNode = tmp;

            while (tmpNode.Next != null)//проход по списку
            {
                tmpNode = tmpNode.Next;//ук-ль на след эл-т                
            }

            tmpNode.Next = Root;
            Root = tmp;
        }

        public void HalfUneven(int count)
        {
            Node<T> current = Root; //ук-ль на начало списка
            Node<T> tmp1 = Root;
            Node<T> end = GetLastNode();
            int half = count / 2;

            for (int i = 0; i < half; i++)
            {
                current = current.Next;
            }


            Root = current.Next;

            end.Next = current;
            current.Next = tmp1;


            for (int i = 0; i < count; i++)
            {
                current = current.Next;
            }

            current.Next = null;
        }

        public T[] Mix() //перемаешивание
        {
            Random rnd = new Random();

            for (int i = 0; i < Count; i++)
            {
                int r = rnd.Next(Count);
                Node<T> current = GetTActNode(i);
                Node<T> tmp1 = GetTActNode(r);
                if (current == Root)
                {
                    if (tmp1 != Root)
                    {
                        Node<T> tmp2 = GetTActNode(r - 1);
                        Node<T> tmp3 = tmp1.Next;
                        tmp2.Next = current;
                        Node<T> tmp4 = current.Next;
                        current.Next = tmp3;
                        Root = tmp1;
                        Root.Next = tmp4;
                    }
                }
                else
                {
                    Node<T> tmp2 = GetTActNode(r - 1);
                    Node<T> tmp3 = tmp1.Next;
                    Node<T> tmp4 = current.Next;
                    tmp2.Next = current;
                    GetTActNode(i - 1).Next = tmp1;
                    tmp1.Next = tmp4;
                    current.Next = tmp3;
                }



            }
            return ConvertToArr(Root);
        }

        public T[] Remove(int index) //удаление по индексу
        {
            if (index < Count)
            {
                Node<T> t = GetTActNode(index);
                Node<T> n = GetTActNode(index - 1);
                n.Next = t.Next;
                Count--;
            }
            return ConvertToArr(Root);
        }

        public T[] Reverse()
        {
            Node<T> tmpNode = Root, n = null; //ук-ль на начало списка

            while (tmpNode != null)
            {
                Node<T> tmp = tmpNode.Next;
                tmpNode.Next = n;
                n = tmpNode;
                tmpNode = tmp;
            }
            Root = n;

            return ConvertToArr(Root);
        }

        public T[] SortToDecr() //сортировка по убыванию
        {
            Node<T> current = Root;
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
                                Node<T> tmp = current.Next;
                                current.Next = current.Next.Next;
                                tmp.Next = current;
                                Root = tmp;
                            }
                            else
                            {
                                Node<T> tmp1 = current.Next;
                                Node<T> tmp2 = current.Next.Next;
                                current.Next = tmp2;
                                tmp1.Next = current;
                                Node<T> tmp3 = Root;
                                while (tmp3.Next != current)
                                {
                                    tmp3 = tmp3.Next;
                                }
                                tmp3.Next = tmp1;
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

        public T[] SortToIncr() //сортировка по возрастанию
        {
            int count = 0;
            Node<T> tmpNode = Root; //ук-ль на начало списка
            //опт решение 4 вложенных while
            while (tmpNode != null)//проход по списку
            {
                count++;//считает количество элементов
                tmpNode = tmpNode.Next;//ук-ль на след эл-т
            }

            tmpNode = Root;//промежуточная

            for (int i = 0; i < count; i++)
            {
                Node<T> minNode;//нахождение точки начала
                tmpNode = Root;
                for (int j = 0; j < i; j++)
                {
                    tmpNode = tmpNode.Next;
                }
                minNode = tmpNode;

                while (tmpNode != null)//находим мин эл-т
                {
                    if (minNode.Value.CompareTo(tmpNode.Value) > 0)
                    {
                        minNode = tmpNode;
                    }
                    tmpNode = tmpNode.Next;
                }

                if (minNode == Root)
                    continue;

                tmpNode = Root;

                while (tmpNode.Next != minNode)//ищем элемент перд минимальным
                {
                    tmpNode = tmpNode.Next;
                }
                tmpNode.Next = minNode.Next;//удаляем мин эл-т из списка

                if (i == 0)
                {
                    minNode.Next = Root;
                    Root = minNode;
                }
                else
                {
                    tmpNode = Root;
                    for (int j = 1; j < i; j++)
                    {
                        tmpNode = tmpNode.Next;
                    }
                    minNode.Next = tmpNode.Next;
                    tmpNode.Next = minNode;
                }
            }

            return ConvertToArr(Root);
        }

        public void Print()
        {
            Node<T> tmpNode = Root;

            while (tmpNode != null)
            {
                Console.Write(tmpNode.Value + " ");
                tmpNode = tmpNode.Next;
            }
            Console.WriteLine();
        }
    }
}
