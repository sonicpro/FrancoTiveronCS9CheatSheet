using System.Linq;
using Xunit;
using static FrancoTiveronCS9CheatSheet.Pattern_Matching.SwitchExpression.ScoreEvaluator;

namespace XUnitTests
{
    public class SwitchExpression
    {
        [Fact]
        public void Test()
        {
            // Enumarate over "scores" from -1 to 10 and test whether switch expression
            // matches the scores correctly.
            Assert.All(
                Enumerable.Range(-1, 12),
                s => Assert.Equal(SwitchStatement(s), SwitchExpression(s)));
        }
    }
}
