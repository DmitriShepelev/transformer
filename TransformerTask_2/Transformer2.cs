using System;
using System.Collections.Generic;

namespace TransformerTask_2
{
    public class Transformer2
    {
        public string TransformToWord(double number)
        {
            return number.ToWords();
        }

        public string[] TransformToWord(double[] arr)
        {
            var list = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i].ToWords());
            }

            return list.ToArray();
        }

        public string TransfarmToIEEE754(double number)
        {
            return number.ToIEEE754Format();
        }

        public string[] TransfarmToIEEE754(double[] arr)
        {
            var list = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(arr[i].ToIEEE754Format());
            }

            return list.ToArray();
        }
    }
}
