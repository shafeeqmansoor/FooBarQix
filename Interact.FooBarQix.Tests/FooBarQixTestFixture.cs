using Interact.FooBarQix.Interfaces;
using Interact.FooBarQix.Rules;
using NUnit.Framework;

namespace Interact.FooBarQix.Tests
{
    [TestFixture]
    public class FooBarQixTestFixture
    {
        private IFooBarQixRules _stepOneRules;
        private IFooBarQixRules _stepTwoRules;

        [SetUp]
        public void Setup()
        {
            _stepOneRules = new FooBarQixStepOneRules();
            _stepTwoRules = new FooBarQixStepTwoRules();
        }

        [Test]
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        [TestCase("3", "FooFoo")]
        [TestCase("4", "4")]
        [TestCase("5", "BarBar")]
        [TestCase("6", "Foo")]
        [TestCase("7", "QixQix")]
        [TestCase("8", "8")]
        [TestCase("9", "Foo")]
        [TestCase("10", "Bar")]
        [TestCase("13", "Foo")]
        [TestCase("15", "FooBarBar")]
        [TestCase("21", "FooQix")]
        [TestCase("33", "FooFooFoo")]
        [TestCase("51", "FooBar")]
        [TestCase("53", "BarFoo")]
        [TestCase("101", "101")]
        [TestCase("303", "FooFooFoo")]
        [TestCase("105", "FooBarQixBar")]
        [TestCase("10101", "FooQix")]
        [TestCase("9223372036854775807", "QixFooFooQixFooBarQixQixBarQix", Category ="Boundary Case", Description = "Upper Limit")]
        [TestCase("9223372036854775808", "9223372036854775808", Category = "Boundary Case", Description = "Upper Limit Breached")]
        [TestCase("-9223372036854775808", "FooFooQixFooBarQixQixBar", Category = "Boundary Case", Description = "Lower Limit")]
        [TestCase("-9223372036854775809", "-9223372036854775809", Category = "Boundary Case", Description = "Lower Limit Breached")]
        [TestCase("", "", Category = "Validation", Description = "Invalid Input")]
        [TestCase(null, null, Category = "Validation", Description = "Invalid Input")]
        [TestCase("aBCxYz1234%*@#", "aBCxYz1234%*@#", Category = "Validation", Description = "Invalid Input")]
        public void FooBarQix_Step_One_Rules_Verify(string inputText, string expectedOutput)
        {
            //Arrange
            var subject = new FooBarQixGenerator(_stepOneRules);

            //Act
            var actualOutput = subject.Compute(inputText);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        [TestCase("3", "FooFoo")]
        [TestCase("4", "4")]
        [TestCase("5", "BarBar")]
        [TestCase("6", "Foo")]
        [TestCase("7", "QixQix")]
        [TestCase("8", "8")]
        [TestCase("9", "Foo")]
        [TestCase("10", "Bar*")]
        [TestCase("13", "Foo")]
        [TestCase("15", "FooBarBar")]
        [TestCase("21", "FooQix")]
        [TestCase("33", "FooFooFoo")]
        [TestCase("51", "FooBar")]
        [TestCase("53", "BarFoo")]
        [TestCase("101", "1*1")]
        [TestCase("303", "FooFoo*Foo")]
        [TestCase("105", "FooBarQix*Bar")]
        [TestCase("10101", "FooQix**")]
        [TestCase("9223372036854775807", "QixFooFooQix*FooBarQixQixBar*Qix", Category = "Boundary Case", Description = "Upper Limit")]
        [TestCase("9223372036854775808", "9223372036854775808", Category = "Boundary Case", Description = "Upper Limit Breached")]
        [TestCase("-9223372036854775808", "-9223372*368547758*8", Category = "Boundary Case", Description = "Lower Limit")]
        [TestCase("-9223372036854775809", "-9223372036854775809", Category = "Boundary Case", Description = "Lower Limit Breached")]
        [TestCase("", "", Category ="Validation", Description ="Invalid Input")]
        [TestCase(null, null, Category = "Validation", Description = "Invalid Input")]
        [TestCase("aBCxYz1234%*@#", "aBCxYz1234%*@#", Category = "Validation", Description = "Invalid Input")]
        public void FooBarQix_Step_Two_Rules_Verify(string inputText, string expectedOutput)
        {
            //Arrange
            var subject = new FooBarQixGenerator(_stepTwoRules);

            //Act
            var actualOutput = subject.Compute(inputText);

            //Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}