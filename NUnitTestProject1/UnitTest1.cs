using NUnit.Framework;

namespace List
{    
    [TestFixture(typeof(AList0<int>))]
    [TestFixture(typeof(LList1<int>))]
    [TestFixture(typeof(LList2<int>))]
    public class TestsInterf<T> where T : IList1<int>, new()
    {
        IList1<int> TestList;
        
        [SetUp]
        public void Setup()
        {
            this.TestList = new T();
        }

        [TestCase(1, ExpectedResult = new int[] { 1 })]        
        [TestCase(0, ExpectedResult = new int[] { 0 })]
        [TestCase(100000000, ExpectedResult = new int[] { 100000000 })]
        public int[] TestAdd(int a)
        {
            return TestList.Add(a);

        }
        
        [TestCase(new int[] { 3, 4, 1, 2 }, ExpectedResult = new int[] { 3, 4, 1, 2 })]
        [TestCase(null, ExpectedResult = null)]
        [TestCase(new int[] { 0 }, ExpectedResult = new int[] { 0 })]
        [TestCase(new int[] { 100000000 }, ExpectedResult = new int[] { 100000000 })]
        public int[] TestAdd1(int[] a)
        {
            return TestList.Add(a);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 3, 4, 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, ExpectedResult = new int[] { 4, 5, 3, 1, 2 })]        
        public int[] TestHalf(int[] a)
        {
            TestList.Add(a);
            return TestList.Half();
        }

        [TestCase(new int[] { 10000 }, ExpectedResult = 10000)]
        [TestCase(new int[] { 7, 17, 3, 30, 5 }, ExpectedResult = 30)]
        [TestCase(new int[] { 16, 26, 63, 6, 45, 3 }, ExpectedResult = 63)]
        public int TestFindMax(int[] a)
        {
            TestList.Add(a);
            return TestList.FindMax();
        }

        [TestCase(new int[] { 0, 10000 }, ExpectedResult = 0)]
        [TestCase(new int[] { 7, 17, 3, 30, 5 }, ExpectedResult = 3)]
        [TestCase(new int[] { 16, 26, 63, 6, 45, 1 }, ExpectedResult = 1)]
        public int TestFindMin(int[] a)
        {
            TestList.Add(a);
            return TestList.FindMin();
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, 5,1, ExpectedResult = new int[] { 1, 5, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, null, 1, ExpectedResult = new int[] { 1, 0, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, 1, ExpectedResult = new int[] { 1, 0, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 100000000, 1, ExpectedResult = new int[] { 1, 100000000, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, null, null, ExpectedResult = new int[] {0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 0, null, ExpectedResult = new int[] {0, 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 100000000, null, ExpectedResult = new int[] { 100000000, 1, 2, 3, 4 })]

        public int[] TestAddIndex(int[] a, int newItem, int index)
        {
            TestList.Add(a);
            return TestList.AddIndex(newItem, index);
        }
         
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, ExpectedResult = new int[] { 1, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, ExpectedResult = new int[] { 1, 2, 3, 4 })]        
        [TestCase(new int[] { 1, 2, 3, 4 }, 10, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 3, ExpectedResult = new int[] { 1, 2, 3 })]
        public int[] TestRemove(int[] a, int index)
        {
            TestList.Add(a);
            return TestList.Remove(index);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = new int[] { 4, 3, 2, 1 })]
        public int[] TestReverse(int[] a)
        {
            TestList.Add(a);
            return TestList.Reverse();
        }

        [TestCase(new int[] { 1, 3, 2, 4 }, ExpectedResult = new int[] { 4, 3, 2, 1 })]
        public int[] TestSortToDecr (int[] a)
        {
            TestList.Add(a);
            return TestList.SortToDecr();
        }

        [TestCase(new int[] { 2, 1, 4, 3 }, ExpectedResult = new int[] { 1, 2, 3, 4 })]
        public int[] TestSortToIncr(int[] a)
        {
            TestList.Add(a);
            return TestList.SortToIncr();
        }       
    }
}