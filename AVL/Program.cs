using System;

namespace AVL
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tr = new Tree<int>();
            tr.Add(10);
            tr.Add(3);
            tr.Add(2);
            tr.Add(4);
            tr.Add(12);
            tr.Add(15);
            tr.Add(11);

            //Console.WriteLine(tr.Contains(10));
            //Console.WriteLine(tr.Contains(3));
            //Console.WriteLine(tr.Contains(2));
            //Console.WriteLine(tr.Contains(4));
            //Console.WriteLine(tr.Contains(12));
            //Console.WriteLine(tr.Contains(15));
            //Console.WriteLine(tr.Contains(11));   
           
        }
    }
}
