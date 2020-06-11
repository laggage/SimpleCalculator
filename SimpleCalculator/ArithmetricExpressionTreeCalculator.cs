using System;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;

namespace SimpleCalculator
{
    public class ExpressionTreeArithmetricCalculator : IArithmetricCalculator
    {
        private static ExpressionTreeArithmetricCalculator _calculator;

        private Expression _expr;
        private Func<double> _calculate;

        private ExpressionTreeArithmetricCalculator(Expression expr)
        {
            SetExpr(expr);
        }

        private void SetExpr(Expression expr)
        {
            _expr=expr ?? throw new ArgumentNullException(nameof(expr));
            _calculate = Expression.Lambda<Func<double>>(_expr).Compile();
        }

        public double Calculate()
        {
            return _calculate.Invoke();
        }

        public static IArithmetricCalculator Create(Expression expr)
        {
            if (_calculator == null) _calculator = new ExpressionTreeArithmetricCalculator(expr);

            else _calculator.SetExpr(expr);

            return _calculator;
        }

        public static IArithmetricCalculator Create(string exprText)
        {
            try
            {
                BinaryExpression expression = new ArithmetricExpressionBuilder(exprText).Build();
                return Create(expression);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                throw new InvalidExpressionException("Fatal error, unsupported syntax, please check user input!", ex);
            }
        }

        public bool TryCalculate(out double result)
        {
            try
            {
                result = Calculate();
                return true;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                result = 0;
                return false;
            }
        }
    }
}
