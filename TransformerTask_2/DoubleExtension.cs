using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace TransformerTask_2
{
    static class DoubleExtension
    {
        public static string ToIEEE754Format(this double number)
        {
            UnionStruct x = new UnionStruct
            {
                D = number,
            };
            return x.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct UnionStruct
        {
            [FieldOffset(0)]
            public double D;

            [FieldOffset(0)]
            private long l;

            public new string ToString()
            {
                long mask = 0x01;
                var result = new char[64];
                for (int i = 0; i < 64; i++)
                {
                    if ((this.l & mask) == 0)
                    {
                        result[i] = '0';
                    }
                    else
                    {
                        result[i] = '1';
                    }

                    mask <<= 1;
                }

                Array.Reverse(result);
                return new string(result);
            }
        }

        public static string ToWords(this double number)
        {
            if (double.IsNaN(number))
            {
                return "Not a Number";
            }

            if (double.IsPositiveInfinity(number))
            {
                return "Positive Infinity";
            }

            if (double.IsNegativeInfinity(number))
            {
                return "Negative Infinity";
            }

            if (number == double.Epsilon)
            {
                return "Double Epsilon";
            }

            var dict = new Dictionary<char, string>()
            {
                { '-', "Minus" },
                { '0', "zero" },
                { ',', "point" },
                { '.', "point" },
                { '1', "one" },
                { '2', "two" },
                { '3', "three" },
                { '4', "four" },
                { '5', "five" },
                { '6', "six" },
                { '7', "seven" },
                { '8', "eight" },
                { '9', "nine" },
                { 'E', "E" },
                { '+', "plus" },
            };

            var sb = new StringBuilder();
            for (int i = 0; i < number.ToString().Length; i++)
            {
                sb.Append(dict[number.ToString()[i]]);
                sb.Append(" ");
            }

            sb[0] = char.ToUpper(sb[0]);
            return new string(sb.ToString().TrimEnd());
        }
    }
}
