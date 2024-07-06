using InterviewTestQA.InterviewTestAutomation;
using System.Linq.Expressions;

namespace InterviewTestQA
{

    public class CalculatorTest
    {

        Calculator calculator = new Calculator();
        [Fact]
        public void AdditionPositive()
        {
            int result = calculator.Add(22435454, 98776565);
            Assert.Equal(121212019, result);
            result = calculator.Add(22, -9);
            Assert.Equal(13, result);

        }
        [Fact]
        public void AdditionNegative()
        {
            int result = calculator.Add(-221, -36778);
            Assert.Equal(-36999, result);

        }
        [Fact]
        public void SubstractionNegative()
        {
            int result = calculator.Subtract(-2, -3);
            Assert.Equal(1, result);
            result = calculator.Subtract(-7, 3);
            Assert.Equal(-10, result);

        }
        [Fact]
        public void Substractionpositive()
        {
            int result = calculator.Subtract(2, 3);
            Assert.Equal(-1, result);
            result = calculator.Subtract(12345566, 23456);
            Assert.Equal(12322110, result);
        }
        [Fact]
        public void MultiplyNegative()
        {
            int result = calculator.Multiply(-12, -3);
            Assert.Equal(36, result);
            result = calculator.Multiply(0, -3);
            Assert.Equal(0, result);
            result = calculator.Multiply(1, -100);
            Assert.Equal(-100, result);

        }
        [Fact]
        public void Multiplypositive()
        {
            int result = calculator.Multiply(2, 3);
            Assert.Equal(6, result);
            result = calculator.Multiply(12345566, 23456);
            Assert.Equal(1814787264, result);
        }

        [Fact]
        public void DivideNegative()
        {
            int result = calculator.Divide(-12, -3);
            Assert.Equal(4, result);
            result = calculator.Divide(0, -3);
            Assert.Equal(0, result);
            result = calculator.Divide(100, -100);
            Assert.Equal(-1, result);

        }
        [Fact]
        public void DividePositive()
        {
            int result = calculator.Divide(2, 3);
            Assert.Equal(0, result);
            result = calculator.Divide(12345566, 23456);
            Assert.Equal(526, result);
        }
        [Fact]
        public void DivideZero()
        {
            var exceptionType = typeof(ArgumentException);
            Assert.Throws(exceptionType, () =>
            {
                calculator.Divide(0, 0);
            });
        }
        [Fact]
        public void SqaurerootZero()
        {
            var exceptionType = typeof(ArgumentException);
            Assert.Throws(exceptionType, () =>
            {
                calculator.SquareRoot(0);
            });
        }
        [Fact]
        public void SquareNegative()
        {
            int result = calculator.Square(-15);
            Assert.Equal(225, result);
            result = calculator.Square(-0);
            Assert.Equal(0, result);
            result = calculator.Square(-9999);
            Assert.Equal(99980001, result);

        }
        [Fact]
        public void SqarePositive()
        {
            int result = calculator.Square(+10);
            Assert.Equal(100, result);
            result = calculator.Square(10001);
            Assert.Equal(100020001, result);
        }
        //Square root logic is wrong
        [Fact]
        public void SquarerootNegative()
        {
            int result = calculator.SquareRoot(-15);
            Assert.Equal(1, result);
            result = calculator.SquareRoot(-9999);
            Assert.Equal(1, result);

        }
        [Fact]
        public void SqarerootPositive()
        {
            int result = calculator.SquareRoot(+10);
            Assert.Equal(1, result);
            result = calculator.SquareRoot(12345);
            Assert.Equal(1, result);
        }
    }
}