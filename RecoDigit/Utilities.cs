using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RecoDigit
{
    /// <summary>
    /// A utility class providing universal tools that the <see cref="NeuralNetwork"/> uses, but can exist on their own.
    /// </summary>
    static class Utilities
    {
        /// <summary>
        /// One-Hot encodes a number <paramref name="x"/> using <paramref name="length"/> bits.
        /// </summary>
        /// <typeparam name="T">Any number type.</typeparam>
        /// <param name="x">The number to be encoded.</param>
        /// <param name="length">The number of bits to encode <paramref name="x"/></param>
        /// <returns>One-Hot encoding of <paramref name="x"/> on <paramref name="length"/> bits.</returns>
        /// <exception cref="ArgumentException">If <paramref name="x"/> is greated than <paramref name="length"/> - it will not fit.</exception>
        public static T[] OneHotEncode<T>(int x, int length) where T : struct, INumber<T>
        {
            if (x >= length) throw new ArgumentException("The argument x cannot be one-hot encoded with such length!");

            T[] result = new T[length];
            result[x] = (T)Convert.ChangeType(1, typeof(T));
            return result;
        }

        /// <summary>
        /// Finds the index of the biggest number in an array.
        /// </summary>
        /// <typeparam name="T">Any number type.</typeparam>
        /// <param name="x">An array to find the index of a maximum in.</param>
        /// <returns>The index of the first maximum in the list.</returns>
        /// <remarks>The name of this function comes from numpy, where a function doing what this function is doing is called <c>argmax</c>.</remarks>
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

        /// <summary>
        /// Draws a random double from between two doubles.
        /// </summary>
        /// <param name="left">The left end of the range (inclusive).</param>
        /// <param name="right">The right end of the range (exclusive).</param>
        /// <returns>A random number between <paramref name="left"/> and <paramref name="right"/></returns>
        /// <exception cref="ArgumentException">If <paramref name="right"/> is greater than <paramref name="left"/></exception>
        public static double RandomDoubleRange(double left = -0.5, double right = 0.5)
        {
            if (left > right) throw new ArgumentException("Left cannot be more than right!");
            Random rand = new Random();
            return rand.NextDouble() * (right - left) + left;
        }
    }
}
