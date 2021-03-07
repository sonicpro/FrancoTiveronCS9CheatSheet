using FrancoTiveronCS9CheatSheet.CS8.NullCoalescingOperator;
using Xunit;
using static FrancoTiveronCS9CheatSheet.CS8.NullCoalescingOperator.NullCoalescingOperatorTester;
namespace XUnitTests
{
    public class TestNullCoalescing
    {
        [Fact]
        public static void TestToToFourRefTypesNullCoalescing()
        {
            (object a, object b, object c, object d) = (new object(), null, new object(), null);

            // Craft the combinations of a, b, c, and d objects from 2 to four in length
            // and test if the null coalescing performs the same as the ternary operator.
            for (int i = 2; i < 4; i++)
            {
                foreach (var combination in Combinatory.Combinations(new[] { a, b, c, d }, i))
                    AssertCombination(combination);
            }
        }
    }
}
