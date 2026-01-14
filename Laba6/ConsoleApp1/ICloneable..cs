namespace FractionExample
{
    /// <summary>
    /// Итерфейс, содержащий сигнатурy ICloneable.
    /// </summary>
    public interface ICloneable
    {
        double GetDoubleValue();
        void SetEnumerator(int value);
        void SetDenominator(int value);

    }
}