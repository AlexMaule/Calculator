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
    }
}
