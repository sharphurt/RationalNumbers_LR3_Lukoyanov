﻿using System.Numerics;

 namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Rational number.
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Приведение дроби к несократимому виду
        /// </summary>
        /// <remarks>Canonical form of zero is 0/1.</remarks>
        public Rational CanonicalForm
        {
            get
            {
                if (Numerator.IsZero)
                    return Zero;

                var gcd = BigInteger.GreatestCommonDivisor(Numerator, Denominator);

                if (Denominator.Sign < 0)
                    gcd = BigInteger.Negate(gcd);

                var canonical = new Rational(Numerator / gcd, Denominator / gcd);
                return canonical;
            }
        }
    }
}