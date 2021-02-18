using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStack;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountShouldBeZeroAfterStackCreation()
        {
            var stack = new MyStack<int>();
            Assert.AreEqual(0, stack.Count);
        }
        [TestMethod]
        public void CollectionExistsAfterStackCreation()
        {
            var stack = new MyStack<int>(new int[] { 1, 2, 3 });
            for (int i = 0; i < stack.Count; i++)
            {
                Assert.AreEqual(i + 1, stack[i]);
            }
        }
        [TestMethod]
        public void CapacityIsCorrectAfterStackCreation()
        {
            var stack = new MyStack<int>(16);
            Assert.AreEqual(16, stack.Capacity);
        }

        [TestMethod]
        public void CountIncreasedAfterAdding()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void ItemExistsAfterAdding()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            Assert.AreEqual(stack[0], 1);
        }

        [TestMethod]
        public void CountIncreasedAfterRangeAdding()
        {
            var stack = new MyStack<int>();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                stack.Push(i);
            }
            Assert.AreEqual(100, stack.Count);
        }

        [TestMethod]
        public void ItemsExistAfterRangeAdding()
        {
            var stack = new MyStack<int>();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                stack.Push(i);
            }
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(i, stack[i]);
            }
        }
        [TestMethod]
        public void CountDecreasedAfterRemoving()
        {
            var stack = new MyStack<int>(new int[] { 1, 2, 3 });
            stack.Pop();
            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod]
        public void ItemDoesNotExistAfterRemoving()
        {
            var stack = new MyStack<int>(new int[] { 1, 2, 3 });
            stack.Pop();
            for (int i = 0; i < stack.Count; i++)
            {
                Assert.AreEqual(i + 1, stack[i]);
            }
        }
        [TestMethod]
        public void PeekReturnsCorrectItem()
        {
            var stack = new MyStack<int>(new int[] { 1, 2, 3 });
            Assert.AreEqual(3, stack.Peek());
        }
        [TestMethod]
        public void ContainsReturnsTrueIfItemExists()
        {
            var stack = new MyStack<int>(new int[] { 1, 2, 3 });
            Assert.AreEqual(true, stack.Contains(2));
        }
        [TestMethod]
        public void ContainsReturnsFalseIfItemDoesNotExists()
        {
            var stack = new MyStack<int>(new int[] { 1, 2, 3 });
            Assert.AreEqual(false, stack.Contains(4));
        }
    }
}
