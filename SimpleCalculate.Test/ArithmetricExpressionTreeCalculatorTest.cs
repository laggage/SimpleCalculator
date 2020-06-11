using SimpleCalculator;
using System;
using System.Data;
using Xunit;

namespace SimpleCalculate.Test
{
    public class ArithmetricExpressionTreeCalculatorTest
    {
        [Theory]
        [InlineData("-8+(-8)", -16)]
        [InlineData("-5+(-5)+35^3+14*(52+9)", 43719)]
        [InlineData("-16+4", -12)]
        [InlineData("16+4", 20)]
        [InlineData("16-2^2+14/7", 14)]
        [InlineData("16-2^2+14*7", 110)]
        [InlineData("(99+66)*5/5",165)]
        [InlineData("(99+66)*5/5-6/3-(99)", 64)]
        [InlineData("5%2", 1)]
        [InlineData("5%2+3^2", 10)]
        [InlineData("10^3+5", 1e+3 + 5)]
        public void CalculateTest(string exprText, double expect)
        {
            IArithmetricCalculator calculator = ExpressionTreeArithmetricCalculator.Create(exprText);
            double res = calculator.Calculate();
            Assert.Equal(expect, res);
        }

        [Theory]
        [InlineData("-8+(-8)", -16)]
        [InlineData("-5+(-5)+35^3+14*(52+9)", 43719)]
        [InlineData("-16+4", -12)]
        [InlineData("16+4", 20)]
        [InlineData("16-2^2+14/7", 14)]
        [InlineData("16-2^2+14*7", 110)]
        [InlineData("(99+66)*5/5", 165)]
        [InlineData("(99+66)*5/5-6/3-(99)", 64)]
        [InlineData("5%2", 1)]
        [InlineData("5%2+3^2", 10)]
        [InlineData("10^3+5", 1e+3 + 5)]
        public void TryCalculateTest(string exprText, double expect)
        {
            IArithmetricCalculator calculator = ExpressionTreeArithmetricCalculator.Create(exprText);
            bool success = calculator.TryCalculate(out double result);
            Assert.Equal(expect, result);
        }

        [Fact]
        public void CalculateTest_Throws()
        {
            string exprText = "55++6";

            Assert.Throws<InvalidExpressionException>(() => ExpressionTreeArithmetricCalculator.Create(exprText));
        }
    }
}
