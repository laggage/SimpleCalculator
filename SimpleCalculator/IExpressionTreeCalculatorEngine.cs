using System.Linq.Expressions;

namespace SimpleCalculator
{
    internal interface IExpressionTreeCalculatorEngine
    {
        double Calculate(Expression expression);
    }
}
