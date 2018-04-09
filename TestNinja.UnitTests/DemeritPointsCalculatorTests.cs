using NUnit.Framework;
using TestNinja.Fundamentals;
using System;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedLessThanZeroOrGreaterThanMaxSpeed_ThenThrowException(int speed)
        {
            var demeritCalc = new DemeritPointsCalculator();
            //var result = demeritCalc.CalculateDemeritPoints(input);

            Assert.That(() => demeritCalc.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(64)]
        [TestCase(65)]
        public void CalculateDemeritPoints_WhenSpeedGreaterThanZeroAndLesserThanOrEqualToSpeedLimit_ThenReturnZero(int speed)
        {
            var demeritCalc = new DemeritPointsCalculator();
            var result = demeritCalc.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase(66,0)]
        [TestCase(69, 0)]
        [TestCase(70, 1)]
        [TestCase(71, 1)]
        [TestCase(75, 2)]
        [TestCase(299, 46)]
        [TestCase(300, 47)]
        public void CalculateDemeritPoints_WhenSpeedGreaterThanSpeedLimitAndLesserThanOrEqualToMaxSpeed_ThenReturnDemeritPoints(int speed, int expectedResult)
        {
            var demeritCalc = new DemeritPointsCalculator();
            var result = demeritCalc.CalculateDemeritPoints(speed);

            Assert.That(result, Is.EqualTo(expectedResult));

        }

    }
}
