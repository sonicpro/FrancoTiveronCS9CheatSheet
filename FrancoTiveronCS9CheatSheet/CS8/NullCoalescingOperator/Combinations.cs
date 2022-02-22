using System.Collections.Generic;

namespace FrancoTiveronCS9CheatSheet.CS8.NullCoalescingOperator
{
    public static class Combinatory
    {
        /// <summary>
        /// Returns an array of arrays. Each array contains "size" elements from "array" argument witout permutations.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="array">An array to combine elements from.</param>
        /// <param name="size">The number of element in each combination.</param>
        /// <returns>An array of combinations. The array length is array.Length! / (size! * (array.Length - size)!).</returns>
        public static IEnumerable<T[]> Combinations<T>(T[] array, int size)
        {
            T[] result = new T[size];
            foreach (int[] j in ComposeIndicesFromLengthBySize(size, array.Length))
            {
                for (int i = 0; i < size; i++)
                {
                    result[i] = array[j[i]];
                }
                yield return result;
            }
        }
        private static IEnumerable<int[]> ComposeIndicesFromLengthBySize(int size, int length)
        {
            int[] result = new int[size];
            Stack<int> stack = new Stack<int>(size);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < length)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != size) continue;
                    yield return (int[])result.Clone();
                    break;
                }
            }
        }
    }
}
