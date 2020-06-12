using System;
using System.Linq.Expressions;

namespace SimpleCalculator
{
    internal class DefaultCalculatorEngine : IExpressionTreeCalculatorEngine
    {
        public double Calculate(Expression expression)
        {
            Func<double> calculate = Expression.Lambda<Func<double>>(expression).Compile();
            return calculate();
        }
    }
}
