using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Рациональное число
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Инверсия числа
        /// </summary>
        public static Rational Invert(Rational p)
        {
            var numerator = p.Denominator;
            var denominator = p.Numerator;
            var result = new Rational(numerator, denominator);
            return result;
        }

        /// <summary>
        /// Отрицание числа
        /// </summary>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static Rational Negate(Rational p)
        {
            if (p.IsZero)
                return Zero;

            BigInteger numerator;
            BigInteger denominator;
            if (p.Denominator < 0)
            {
                numerator = p.Numerator;
                denominator = BigInteger.Negate(p.Denominator);
            }
            else
            {
                numerator = BigInteger.Negate(p.Numerator);
                denominator = p.Denominator;
            }
            var result = new Rational(ref numerator, ref denominator);
            return result;
        }

        /// <summary>
        /// Сумма двух чисел
        /// </summary>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static Rational Add(Rational left, Rational right)
        {
            if (right.IsZero)
                return left;

            if (left.IsZero)
                return right;

            var numerator = left.Numerator * right.Denominator + left.Denominator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var sum = new Rational(ref numerator, ref denominator);
            return sum;
        }

        /// <summary>
        /// Разность одного числа и другого
        /// </summary>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static Rational Subtract(Rational left, Rational right)
        {
            if (right.IsZero)
                return left;

            if (left.IsZero)
                return -right;

            var numerator = left.Numerator * right.Denominator - left.Denominator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var difference = new Rational(ref numerator, ref denominator);
            return difference;
        }

        /// <summary>
        /// Произведение двух чисел
        /// </summary>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static Rational Multiply(Rational left, Rational right)
        {
            if (left.IsZero || right.IsZero)
                return Zero;

            var numerator = left.Numerator * right.Numerator;
            var denominator = left.Denominator * right.Denominator;
            var product = new Rational(ref numerator, ref denominator);
            return product;
        }

        /// <summary>
        /// Частное двух чисел
        /// </summary>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static Rational Divide(Rational left, Rational right)
        {
            if (right.IsZero)
                throw new DivideByZeroException();

            if (left.IsZero)
                return Zero;

            var numerator = left.Numerator * right.Denominator;
            var denominator = left.Denominator * right.Numerator;
            var quotient = new Rational(ref numerator, ref denominator);
            return quotient;
        }

        /// <summary>
        /// Возведение рациональног числа в степень целого числа
        /// </summary>
        public static Rational Pow(Rational number, int exponent)
        {
            if (exponent == 1)
                return number;

            if (exponent == 0)
                return One;

            if (number.IsOne)
                return number;

            if (number.IsZero)
            {
                if (exponent < 0)
                    throw new DivideByZeroException("Cannot exponentiate zero to negative exponent.");

                return number;
            }

            if (exponent > 0)
            {
                var numerator = BigInteger.Pow(number.Numerator, exponent);
                var denominator = BigInteger.Pow(number.Denominator, exponent);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
            else
            {
                var numerator = BigInteger.Pow(number.Denominator, -exponent);
                var denominator = BigInteger.Pow(number.Numerator, -exponent);
                var result = new Rational(ref numerator, ref denominator);
                return result;
            }
        }

        /// <summary>
        /// Модуль числа
        /// </summary>
        public static Rational Abs(Rational p)
        {
            if (p.IsZero)
                return Zero;

            var numerator = BigInteger.Abs(p.Numerator);
            var denominator = BigInteger.Abs(p.Denominator);
            var result = new Rational(ref numerator, ref denominator);
            return result;
        }

        /// <summary>
        /// Десятичный логарифм числа
        /// </summary>
        public static double Log10(Rational p)
        {
            if (p.IsZero)
                return double.NaN;

            var result = BigInteger.Log10(p.Numerator) - BigInteger.Log10(p.Denominator);
            return result;
        }

        /// <summary>
        /// Натуральный логарифм числа
        /// </summary>
        public static double Log(Rational p)
        {
            if (p.IsZero)
                return double.NaN;

            var result = BigInteger.Log(p.Numerator) - BigInteger.Log(p.Denominator);
            return result;
        }

        /// <summary>
        /// Логарифм числа по основанию baseValue
        /// </summary>
        public static double Log(Rational p, double baseValue)
        {
            if (p.IsZero)
                return double.NaN;

            var result = BigInteger.Log(p.Numerator, baseValue) - BigInteger.Log(p.Denominator, baseValue);
            return result;
        }

        /// <summary>
        /// Корень степени radix из числа 
        /// </summary>
        public static double Root(Rational number, double radix)
        {
            switch (radix)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                case 1:
                    return (double)number;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                case 0:
                    throw new InvalidOperationException("Cannot use zero radix.");
            }

            if (number.IsOne)
                return 1;

            if (number.IsZero)
            {
                if (radix < 0)
                    throw new DivideByZeroException("Cannot root zero to negative exponent.");

                return 0;
            }

            if (number < 0)
                throw new InvalidOperationException("Cannot compute root of negative number.");

            var result = Math.Pow((double)number, 1 / radix);
            return result;
        }
    }
}