using System.Collections.Generic;
using System.Linq;
using Xunit;
using FrancoTiveronCS9CheatSheet.TypeExtensibility.ForEachLoopDetectsExtensionGetEnumeratorMethod;

namespace XUnitTests
{
	public class ForEachLoopTest
	{
		[Fact]
		public void TestForEachLoopAndLinq()
		{
			var ports = new HashSet<string>(new[] { "New York", "Miami", "Los Angeles", "NewOrleans", "Jacksonville", "Houston" });

			var trueEnumerable = new EnumerableCruise();
			// For the real enumerable we can use Linq methods like Cast<T>():
			Assert.All(trueEnumerable.Cast<object>(), c => Assert.Contains(c, ports));

			var nonEnumerableExtended = new NonEnumerableCruise();
			// For the class extended with GetEnumerator method we cannot use Linq methods:
			//Assert.All(nonEnumerableExtended.Cast<object>(), c => Assert.Contains(c, ports));

			// We can only use the instances of classes extended with GetEnumerator() in foreach loops:
			foreach (UsPortsEnum port in nonEnumerableExtended)
			{
				Assert.Contains(port.ToString(), ports);
			}
		}
	}
}
