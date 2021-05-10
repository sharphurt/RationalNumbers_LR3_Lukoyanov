namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Рациональное число
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Проверка, является ли число нулем
        /// </summary>
        public bool IsZero => Numerator.IsZero;

        /// <summary>
        /// Проверка, является ли число единицей
        /// </summary>
        public bool IsOne => Numerator == Denominator;

        /// <summary>
        /// Возвращает число, показывающее знак (отрицательное, положительное, ноль)
        /// </summary>
        public int Sign => Numerator.Sign * Denominator.Sign;
    }
}