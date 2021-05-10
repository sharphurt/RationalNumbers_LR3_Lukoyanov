using System;

namespace RationalNumbers_LR3_Lukoyanov
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var d = Rational.Rational.SeparateOnWholeAndPeriod(new Rational.Rational(111111111, 1000000000));
        }
    }
}