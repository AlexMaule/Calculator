using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorModel
    {
        public static double Add(double num1, double num2) => num1 + num2;

        public static double Subtract(double num1, double num2) => num1 - num2;

        public static double Divide(double num1, double num2)
        {
            if (num2 == 0) throw new DivideByZeroException();

            else return num1 / num2;
        }
    }
}
