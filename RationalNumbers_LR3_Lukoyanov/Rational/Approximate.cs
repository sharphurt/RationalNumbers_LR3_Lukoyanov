using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Рациональное число
    /// </summary>
    public partial struct Rational
    {
        private static IEnumerable<BigInteger> ExpandToContinuedFraction(decimal d)
        {
            var wholePart = Math.Truncate(d);
            var fractionPart = d - wholePart;
            yield return (BigInteger) wholePart;

            while (fractionPart != 0)
            {
                d = 1m / fractionPart;

                wholePart = Math.Truncate(d);
                fractionPart = d - wholePart;
                yield return (BigInteger) wholePart;
            }
        }

        private static IEnumerable<BigInteger> ExpandToContinuedFraction(double d)
        {
            var wholePart = Math.Truncate(d);
            var fractionPart = d - wholePart;
            yield return (BigInteger) wholePart;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (fractionPart != 0)
            {
                d = 1d / fractionPart;

                wholePart = Math.Truncate(d);
                fractionPart = d - wholePart;
                yield return (BigInteger) wholePart;
            }
        }

        /// <summary>
        /// Преобразование десятичной дроби в рациональное число
        /// </summary>
        /// <param name="input">Десятичное число</param>
        /// <param name="tolerance">Точность преобразования</param>
        /// <returns>Рациональное число</returns>
        public static Rational Approximate(decimal input, decimal tolerance = 0)
        {
            if (tolerance < 0) throw new ArgumentOutOfRangeException(nameof(tolerance));
            var continuedFraction = ExpandToContinuedFraction(input);

            var sequence = new List<BigInteger>();
            var previousDifference = decimal.MaxValue;
            var currentNumber = Zero;
            foreach (var coefficient in continuedFraction)
            {
                sequence.Add(coefficient);
                currentNumber = FromContinuedFraction(sequence);
                var currentDifference = Math.Abs((decimal) currentNumber - input);

                if (currentDifference <= tolerance)
                    break;
                if (currentDifference < previousDifference)
                    previousDifference = currentDifference;
                else
                    break;
            }

            return currentNumber;
        }

        /// <summary>
        /// Преобразование десятичной дроби повышенной точности в рациональное число
        /// </summary>
        /// <param name="input">Десятичное число</param>
        /// <param name="tolerance">Точность преобразования</param>
        /// <returns>Рациональное число</returns>
        public static Rational Approximate(double input, double tolerance = 0)
        {
            if (tolerance < 0) throw new ArgumentOutOfRangeException(nameof(tolerance));
            var continuedFraction = ExpandToContinuedFraction(input);

            var sequence = new List<BigInteger>();
            var previousDifference = double.MaxValue;
            var currentNumber = Zero;
            foreach (var coefficient in continuedFraction)
            {
                sequence.Add(coefficient);
                currentNumber = FromContinuedFraction(sequence);
                var currentDifference = Math.Abs((double) currentNumber - input);
                Debug.WriteLine($"{currentNumber} {currentDifference}");
                if (currentDifference <= tolerance)
                {
                    break;
                }

                if (currentDifference < previousDifference)
                {
                    previousDifference = currentDifference;
                }
                else
                {
                    break;
                }
            }

            return currentNumber;
        }


        public static (BigInteger whole, BigInteger preperiod, BigInteger period) SeparateOnWholeAndPeriod(Rational number)
        {
            var separatedNumber = ((double) number).ToString(CultureInfo.InvariantCulture).Split('.');
            var wholePart = separatedNumber[0];

            if (separatedNumber.Length == 1)
                return (BigInteger.Parse(wholePart), BigInteger.MinusOne, BigInteger.MinusOne);

            var fraction = separatedNumber[1];

            var patternToSearchList = new List<string>();
            for (var i = 0; i < fraction.Length; i++)
            for (var j = 2; j <= fraction.Length / 2; j++)
                if (i + j <= fraction.Length)
                    patternToSearchList.Add(fraction.Substring(i, j));


            var sorted = (from pattern in patternToSearchList
                let startIndex = fraction.IndexOf(pattern, StringComparison.Ordinal)
                where fraction.Substring(startIndex + pattern.Length).StartsWith(pattern)
                select pattern).Distinct().ToList();

            if (!sorted.Any())
                return (BigInteger.Parse(wholePart), BigInteger.Parse(fraction), BigInteger.MinusOne);

            var period = sorted.OrderBy(k => fraction.IndexOf(k, StringComparison.Ordinal)).First();
            var preperiod = fraction.Substring(0, fraction.IndexOf(period, StringComparison.Ordinal));

            return string.IsNullOrEmpty(preperiod)
                ? (BigInteger.Parse(wholePart), BigInteger.MinusOne, BigInteger.Parse(period))
                : (BigInteger.Parse(wholePart), BigInteger.Parse(preperiod), BigInteger.Parse(period));
        }
    }
}