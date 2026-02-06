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

        [Fact]
        public void CalculatorAddMethodTest()
        {
            double result = CalculatorModel.Add(3, 5);
            Assert.Equal(8, result);
        }
    }
}
