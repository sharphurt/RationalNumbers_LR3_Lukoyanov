using System;
using System.Numerics;

namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Рациональное число
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Неявное преобразование от sbyte
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(sbyte n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от byte
        /// </summary>
        public static implicit operator Rational(byte n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от short
        /// </summary>
        public static implicit operator Rational(short n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от ushort
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(ushort n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от int
        /// </summary>
        public static implicit operator Rational(int n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от uint
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(uint n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от long
        /// </summary>
        public static implicit operator Rational(long n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от ulong
        /// </summary>
        [CLSCompliant(false)]
        public static implicit operator Rational(ulong n) => n != 0 ? new Rational(n) : Zero;

        /// <summary>
        /// Неявное преобразование от BigInteger
        /// </summary>
        public static implicit operator Rational(BigInteger n) => !n.IsZero ? new Rational(n) : Zero;
    }
}