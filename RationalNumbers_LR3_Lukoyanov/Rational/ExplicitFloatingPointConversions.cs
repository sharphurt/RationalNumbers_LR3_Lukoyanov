﻿using System.Numerics;

 namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Явное преобраззование рационального числа в число с плавающей точкой, возможно округление
        /// </summary>
        public static explicit operator decimal(Rational rational)
        {
            if (rational < 0)
                return -(decimal)-rational;

            decimal result = 0;
            var numerator = rational.Numerator;
            var denominator = rational.Denominator;
            var scale = 1M;
            var previousScale = 0M;
            while (numerator != 0)
            {
                var divided = BigInteger.DivRem(numerator, denominator, out var rem);

                if (scale == 0)
                {
                    if (divided >= 5)
                        result += previousScale;

                    break;
                }

                result += (decimal)divided * scale;

                numerator = rem * 10;
                previousScale = scale;
                scale /= 10;
            }

            return result;
        }

        /// <summary>
        /// Явное преобраззование рациоонального числа в число с плавающей точкой, возможно округление
        /// </summary>
        public static explicit operator double(Rational rational) => (double)(decimal)rational;

        /// <summary>
        /// Явное преобраззование рациоонального числа в число с плавающей точкой, возможно округление
        /// </summary>
        public static explicit operator float(Rational rational) => (float)(decimal)rational;

        /// <summary>
        /// Нахождение ближайшего рационального из числа с плавающей точкой <seealso cref="Approximate(decimal,decimal)"/>.
        /// </summary>
        public static explicit operator Rational(decimal num) => Approximate(num);

        /// <summary>
        /// Нахождение ближайшего рационального из числа с плавающей точкой <seealso cref="Approximate(decimal,decimal)"/>.
        /// </summary>
        public static explicit operator Rational(double num) => Approximate(num);

        /// <summary>
        /// Нахождение ближайшего рационального из числа с плавающей точкой <seealso cref="Approximate(decimal,decimal)"/>.
        /// </summary>
        public static explicit operator Rational(float num) => Approximate(num);
    }
}