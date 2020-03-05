using AVL;
using NUnit.Framework;


namespace AVLTest
{
    public class Tests
    {       
        Tree<int> TestTree;

        [SetUp]
        public void Setup()
        {
            TestTree = new Tree<int>(new int[] { 15, 2, 10, 4, 11, 16, 7, 5 });
        }

        [TestCase(9, ExpectedResult = true)]
        [TestCase(7, ExpectedResult = true)]
        [TestCase(null, ExpectedResult = true)]
        [TestCase(8, ExpectedResult = true)]
        [TestCase(5, ExpectedResult = true)]
        public bool TestAdd(int a)
        {
            TestTree.Add(a);
            return TestTree.Contains(a);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = true)]
        public bool TestAdd(int[] a)
        {
            return TestTree.Add(a);
        }

        [TestCase(ExpectedResult = 2)]
        public int TestMin()
        {
            return TestTree.FindMin().Value;
        }

        [TestCase(ExpectedResult = 16)]
        public int TestMax()
        {
            return TestTree.FindMax().Value;
        }

        [TestCase(9, ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase(2, ExpectedResult = true)]
        public bool TestRemove(int a)
        {
            return TestTree.Remove(a);
        }

        [TestCase(15, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase(7, ExpectedResult = true)]
        [TestCase(17, ExpectedResult = false)]
        public bool TestContains(int a)
        {
            return TestTree.Contains(a);
        }
    }
}