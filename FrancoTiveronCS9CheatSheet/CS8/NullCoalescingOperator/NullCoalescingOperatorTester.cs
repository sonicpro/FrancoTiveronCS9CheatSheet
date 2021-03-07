using Xunit;

namespace FrancoTiveronCS9CheatSheet.CS8.NullCoalescingOperator
{
    // ?? operator is available starting from C# 6.
    // Starting from C#8 it can be used in generics with the unconstrained type parameter.
    public class NullCoalescingOperatorTester
    {
        /// <summary>
        /// Takes the array of 2 to 4 objects.
        /// Asserts that returning the first non-null element of an array
        /// using the null-coalescing operator works the same as doing so using
        /// the ternary operator.
        /// </summary>
        public static void AssertCombination(object[] combination)
        {
            switch(combination)
            {
                case object[] array when array.Length == 2:
                    var (a, b) = (array[0], array[1]);
                    Assert.Equal(a != null ? a : b, a ?? b);
                    break;
                case object[] array when array.Length == 3:
                    var (c, d, e) = (array[0], array[1], array[2]);
                    Assert.Equal(c != null ? c : d != null ? d : e, c ?? d ?? e);
                    break;
                case object[] array when array.Length == 4:
                    var (f, g, h, i) = (array[0], array[1], array[2], array[3]);
                    Assert.Equal(f != null ? f : g != null ? g : h != null ? h : i, f ?? g ?? h ?? i);
                    break;
            }
        }
    }
}
