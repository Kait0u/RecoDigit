using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RecoDigit
{
    internal class Utilities
    {
        public static T[] OneHotEncode<T>(int x, int length) where T : struct, INumber<T>
        {
            if (x >= length) throw new ArgumentException("The argument x cannot be one-hot encoded with such length!");

            T[] result = new T[length];
            result[x] = (T)Convert.ChangeType(1, typeof(T));
            return result;
        }

        public static int ArgMax<T>(T[] x) where T : struct, INumber<T>
        {
            int result = 0;
            T currMax = x[result];

            for (int i = 0; i < x.Length; ++i)
            {
                if (x[i] > currMax)
                {
                    currMax = x[i];
                    result = i;
                }
            }

            return result;
        }

        public static double RandomDoubleRange(double left = -0.5, double right = 0.5)
        {
            if (left > right) throw new ArgumentException("Left cannot be more than right!");
            Random rand = new Random();
            return rand.NextDouble() * (right - left) + left;
        }
    }
}
