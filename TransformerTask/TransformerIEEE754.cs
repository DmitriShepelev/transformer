using System;
using System.Runtime.InteropServices;

namespace TransformerTask
{
#pragma warning disable S101 // Types should be named in PascalCase
    class TransformerIEEE754 : Transformer
#pragma warning restore S101 // Types should be named in PascalCase
    {
        protected override string GetTransform( double number)
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
    }
}
