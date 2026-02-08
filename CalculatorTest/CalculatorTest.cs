using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace CalculatorTest
{
    public class CalculatorTest
    {

        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(4, -10, -6)]
        [InlineData(4, -4, 0)]
        [InlineData(0, 2, 2)]
        public void CalculatorAddMethodTest(double num1, double num2, double expected)
        {
            double result = CalculatorModel.Add(num1, num2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 5, -2)]
        [InlineData(4, -10, 14)]
        [InlineData(4, -4, 8)]
        [InlineData(0, 2, -2)]
        public void CalculatorSubtractMethodTest(double num1, double num2, double expected)
        {
            double result = CalculatorModel.Subtract(num1, num2);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10, 5, 2)]
        [InlineData(4, -10, -0.4)]
        [InlineData(4, -4, -1)]
        [InlineData(0, 2, 0)]
        public void CalculatorDivideMethodTest(double num1, double num2, double expected)
        {
            double result = CalculatorModel.Divide(num1, num2);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculatorDivideByZeroExceptionTest()
        {
            Assert.Throws<DivideByZeroException>(() => CalculatorModel.Divide(5, 0));
        }

        [Theory]
        [InlineData(10, 5, 50)]
        [InlineData(4, -10, -40)]
        [InlineData(4, 1, 4)]
        [InlineData(0, 2, 0)]
        public void CalculatorMultiplyMethodTest(double num1, double num2, double expected)
        {
            double result = CalculatorModel.Multiply(num1, num2);
            Assert.Equal(expected, result);
        }

    }

    public class CalculatorViewModelTest
    {
        [Fact]
        public void ClickButton5DisplaysNumberInDisplay()
        {
            var viewModel = new CalculatorViewModel();
            viewModel.DigitCommand?.Execute("5");
            Assert.Equal("5", viewModel.DisplayText);
        }

        [Fact]
        public void ClickNumberButtonDisplaysNumberInDisplay()
        {
            var viewModel = new CalculatorViewModel();
            string numbers = "0123456789";
            for (int i = 0; i < numbers.Length; i++)
            {
                viewModel.DigitCommand?.Execute(numbers[i]);
                Assert.Equal(numbers.Substring(0, i + 1), viewModel.DisplayText);
            }
        }

        [Fact]
        public void Calculates5Plus3Equals8()
        {
            var viewModel = new CalculatorViewModel();
            viewModel.DigitCommand?.Execute("5");
            viewModel.OperationCommand?.Execute("+");
            viewModel.DigitCommand?.Execute("3");
            viewModel.EqualCommand?.Execute("=");
            Assert.Equal("8", viewModel.DisplayText);
        }

        [Fact]
        public void Clears5FromDisplay()
        {
            var viewModel = new CalculatorViewModel();
            viewModel.DigitCommand?.Execute("5");
            viewModel.ClearCommand?.Execute("C");
            Assert.Equal("0", viewModel.DisplayText);
        }
    }
}
