using NUnit.Framework;
using TestNinja.Fundamentals;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBussTests
    {
        [Test]
        public void GetOutput_WhenInputDivisibleby3and5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo("FizzBuzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_WhenInputDivisibleby3ButNotBy5_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(6);

            Assert.That(result, Is.EqualTo("Fizz").IgnoreCase);
        }

        [Test]
        public void GetOutput_WhenInputDivisibleBy5ButNotBy3_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo("Buzz").IgnoreCase);
        }

        [Test]
        public void GetOutput_WhenInputIsNotDivisibleby3and5_ReturnsInput()
        {
            var result = FizzBuzz.GetOutput(8);

            Assert.That(result, Is.EqualTo("8").IgnoreCase);
        }



    }
}
