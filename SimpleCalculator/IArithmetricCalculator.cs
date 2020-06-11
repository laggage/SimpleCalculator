namespace SimpleCalculator
{
    public interface IArithmetricCalculator
    {
        public double Calculate();
        public bool TryCalculate(out double result);
    }
}
