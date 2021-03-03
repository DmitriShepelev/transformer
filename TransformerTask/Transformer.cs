using System.Collections.Generic;

namespace TransformerTask
{
    /// <summary>
    /// Implement transformer class.
    /// </summary>
    public abstract class Transformer
    {
        public string Transform(double number)
        {
            return this.GetTransform(number);
        }

        public string[] Transform(double[] arr)
        {
            var list = new List<string>();

            for (int i = 0; i < arr.Length; i++)
            {
                list.Add(this.GetTransform(arr[i]));
            }

            return list.ToArray();
        }

        protected abstract string GetTransform(double number);
    }
}