﻿using System;

 namespace RationalNumbers_LR3_Lukoyanov.Rational
{
    /// <summary>
    /// Рациональное число
    /// </summary>
    public partial struct Rational
    {
        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator sbyte(Rational rational) => (sbyte)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        public static explicit operator byte(Rational rational) => (byte)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator ushort(Rational rational) => (ushort)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        public static explicit operator short(Rational rational) => (short)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator uint(Rational rational) => (uint)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        public static explicit operator int(Rational rational) => (int)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        [CLSCompliant(false)]
        public static explicit operator ulong(Rational rational) => (ulong)rational.WholePart;

        /// <summary>
        /// Возвращает целую часть числа
        /// </summary>
        public static explicit operator long(Rational rational) => (long)rational.WholePart;
    }
}