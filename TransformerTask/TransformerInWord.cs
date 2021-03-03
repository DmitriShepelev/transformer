using System.Collections.Generic;
using System.Text;

namespace TransformerTask
{
    class TransformerInWord : Transformer
    {
        protected override string GetTransform(double number)
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
