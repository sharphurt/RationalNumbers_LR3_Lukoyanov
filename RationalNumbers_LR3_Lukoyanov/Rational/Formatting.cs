using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;

namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Rational number.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "}")]
    public partial struct Rational : IFormattable
    {
        /// <summary>
        /// Перечисление значащих цифр рационального числа
        /// Исключает ведущие и конечные нули (исключение для числа 0)
        /// </summary>
        public IEnumerable<char> Digits
        {
            get
            {
                var numerator = BigInteger.Abs(Numerator);
                var denominator = BigInteger.Abs(Denominator);
                var removeLeadingZeros = true;
                var returnedAny = false;
                while (numerator > 0)
                {
                    var divided = BigInteger.DivRem(numerator, denominator, out var rem);

                    var digits = divided.ToString(CultureInfo.InvariantCulture);

                    if (rem == 0)
                        digits = digits.TrimEnd('0');

                    foreach (var digit in digits)
                    {
                        if (removeLeadingZeros && digit == '0')
                            continue;

                        yield return digit;
                        removeLeadingZeros = false;
                        returnedAny = true;
                    }

                    numerator = rem * 10;
                }

                if (!returnedAny)
                    yield return '0';
            }
        }

        /// <summary>
        /// Форматирует число в строку
        /// </summary>
        /// <param name="format">F - для нормальной дроби, C - для канонического представления, W - для представления "Целая часть + дробь"</param>
        /// <param name="formatProvider">Игнорируется</param>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(format);
        }

        /// <summary>
        /// Форматирует число в строку
        /// </summary>
        /// <param name="format">F - для обыкновенной дроби, C - для представления в виде несократимой дроби, W - для представления "Целая часть + дробь"</param>
        public string ToString(string format)
        {
            if (string.IsNullOrEmpty(format)) format = "F";

            switch (format.ToUpperInvariant())
            {
                case "F":
                    return ToString();

                case "W":
                {
                    var whole = WholePart;
                    var fraction = FractionPart.CanonicalForm;
                    if (whole.IsZero)
                        return fraction.ToString();

                    if (fraction.IsZero)
                        return whole.ToString();

                    return string.Format(CultureInfo.InvariantCulture, "{0} + {1}", whole, fraction);
                }
                case "C":
                    return CanonicalForm.ToString();
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            if (Denominator.IsOne)
                return Numerator.ToString();

            if (Numerator.IsZero)
                return 0.ToString(CultureInfo.InvariantCulture);

            return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", Numerator, Denominator);
        }

        private string DebuggerDisplay => Numerator + "/" + Denominator;
    }
}