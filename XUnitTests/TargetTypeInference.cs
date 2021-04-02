using FrancoTiveronCS9CheatSheet.TargetTypeInference;
using Xunit;

namespace XUnitTests
{
	public class TargetTypeInference
	{
		// All the test are related to constructor call.
		// It is not mandatory now to call the constructor by name.

		[Fact]
		public void InferringFromVariableType()
		{
			var data1 = new MyType(13);
			// New way:
			MyType data2 = new(13);
			Assert.Equal(data1, data2);
		}

		[Fact]
		public void InferringFromParameterType()
		{
			int DoubleTheRevenue(MyType revenue) => revenue.Value * 2;

			var revenue1 = DoubleTheRevenue(new MyType(12));
			// New way:
			var revenue2 = DoubleTheRevenue(new(12));
			Assert.Equal(revenue1, revenue2);
		}

		[Fact]
		public void InferringFromVariableTypeWhenUsingObjectInitializer()
		{
			// In the old syntax we do not have to use parenthesis after the constructor name:
			var data1 = new MyType { Value = 26 };
			// In the new sintax we must use the parentethis:
			MyType data2 = new() { Value = 26 };
			Assert.Equal(data1, data2);
		}
	}
}
