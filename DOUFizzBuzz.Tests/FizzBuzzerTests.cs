using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DOUFizzBuzz.Tests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        private FizzBuzzer _sut = null;

        [SetUp]
        public void Initialize()
        {
            _sut = new FizzBuzzer();
        }

        // test the GetAll default
        [Test]
        public void ShouldHaveOneHundredElements()
        {
            var list = _sut.GetAll();
            Assert.That(list.Count, Is.EqualTo(100));
        }

        // test the GetAll with custom lower and upper bounds 
        [Test]
        public void ShouldHaveSeventyFiveElements()
        {
            _sut.NLowerBound = 11;
            _sut.NUpperBound = 85;
            var list = _sut.GetAll();
            Assert.That(list.Count, Is.EqualTo(75));
        }

        // mass test the default GetResult method 
        [Test, TestCaseSource(typeof(TestGetResultDataFactory), "TestGetResultData")]
        public string ShouldHaveDefaultValues(int count)
        {
            return _sut.GetResult(count);
        }

        public class TestGetResultDataFactory
        {
            public static IEnumerable TestGetResultData
            {
                get
                {
                    // not divisible by 3 or 5
                    yield return new TestCaseData(1).Returns("1");
                    yield return new TestCaseData(7).Returns("7");
                    // divisible by 3
                    yield return new TestCaseData(3).Returns("Fizz");
                    yield return new TestCaseData(9).Returns("Fizz");
                    // divisible by 5
                    yield return new TestCaseData(5).Returns("Buzz");
                    yield return new TestCaseData(10).Returns("Buzz");
                    // divisible by both 3 and 5
                    yield return new TestCaseData(15).Returns("Fizz Buzz");
                    yield return new TestCaseData(30).Returns("Fizz Buzz");
                }
            }
        }

        // mass test custom parameters 
        [Test, TestCaseSource(typeof(TestCustomDataFactory), "TestCustomData")]
        public string ShouldHaveCustomValues(int fizz, int buzz, int count)
        {
            _sut.NFizz = fizz;
            _sut.NBuzz = buzz;
            return _sut.GetResult(count);
        }

        public class TestCustomDataFactory
        {
            public static IEnumerable TestCustomData
            {
                get
                {
                    // divisors are 2 and 6
                    yield return new TestCaseData(4, 6, 1).Returns("1");
                    yield return new TestCaseData(4, 6, 8).Returns("Fizz");
                    yield return new TestCaseData(4, 6, 18).Returns("Buzz");
                    yield return new TestCaseData(4, 6, 24).Returns("Fizz Buzz");
                    // divisors are 7 and 9
                    yield return new TestCaseData(7, 9, 5).Returns("5");
                    yield return new TestCaseData(7, 9, 21).Returns("Fizz");
                    yield return new TestCaseData(7, 9, 45).Returns("Buzz");
                    yield return new TestCaseData(7, 9, 63).Returns("Fizz Buzz");
                }
            }
        }


    }
}
