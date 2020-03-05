using System;

namespace List
{
    class Program
    {        
        static void Main(string[] args)
        {
            LList2<int> myList = new LList2<int>(new int[] { 1, 2, 3, 4 });
            myList.Print();
            myList.Add(new int[] { 1, 3, 10, 4, 5 });
            myList.Print();

            //AList0<int> myList1 = new AList0<int>(new int[] { 1, 3, 10, 4, 5 });
            //myList1.Print();
            //myList1.Half();
            //myList1.Print();
        }
    }
}
