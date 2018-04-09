using NUnit.Framework;
using TestNinja.Fundamentals;
using System;

namespace TestNinja.UnitTests
{

    [TestFixture]

    class StackTests_Count
    {
        [Test]
        public void WhenStackEmpty_Returnszero()
        {
            var stack = new Stack<Object>();

            Assert.That(stack.Count, Is.EqualTo(0));
            
        }

        [Test]
        public void WhenStackContainsElement_ReturnCount()
        {
            var stack = new Stack<Object>();

            stack.Push(new Object());
            stack.Push(new Object());

            Assert.That(stack.Count, Is.EqualTo(2));
        }

    }

    class StackTests_Push
    {
        [Test]
        public void WhenInputNull_ThrowsException()
        {
            var stack = new Stack<Object>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void WhenInputObject_IncrementListCount()
        {
            var stack = new Stack<Object>();

            stack.Push(new Object());

            Assert.That(stack.Count, Is.EqualTo(1));
        }

    }

    [TestFixture]
    class StackTests_Pop
    {
        [Test]
        public void WhenStackEmpty_ThrowsException()
        {
            var stack = new Stack<Object>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void WhenStackContainsElement_DecrementListCount()
        {
            var stack = new Stack<Object>();

            stack.Push(new Object());

            var result = stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void WhenStackContainsElement_PopsLastElement()
        {
            var stack = new Stack<Object>();

            var obj1 = new Object();
            var obj2 = new Object();

            stack.Push(obj1);
            stack.Push(obj2);

            var result = stack.Pop();

            Assert.That(result, Is.EqualTo(obj2));
        }

    }

    [TestFixture]
    class StackTests_Peek
    {
        [Test]
        public void WhenStackEmpty_ThrowsException()
        {
            var stack = new Stack<Object>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void WhenStackContainsElement_PeekLastElement()
        {
            var stack = new Stack<Object>();

            var obj1 = new Object();
            var obj2 = new Object();

            stack.Push(obj1);
            stack.Push(obj2);

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo(obj2));
        }

        [Test]
        public void WhenStackContainsElement_DoesntRemoveElement()
        {
            var stack = new Stack<Object>();

            var obj1 = new Object();
            var obj2 = new Object();

            stack.Push(obj1);
            stack.Push(obj2);

            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(2));
        }

    }

}
