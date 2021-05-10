using System.Numerics;

namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    internal static class BigIntegerUtils
    {
        /// <summary>
        /// Возвращает количество цифр числа
        /// </summary>
        public static int GetNumberOfDigits(BigInteger x)
        {
            x = BigInteger.Abs(x);

            var digits = 0;
            while (x > 0)
            {
                digits++;
                x /= 10;
            }

            return digits;
        }
    }
}