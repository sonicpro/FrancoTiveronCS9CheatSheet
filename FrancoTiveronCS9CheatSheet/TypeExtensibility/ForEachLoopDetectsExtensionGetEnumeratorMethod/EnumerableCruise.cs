// "True" enumerable. Implements IEnumerable interface.
// Not only foreach loops available but Linq as well.

using System.Collections;

namespace FrancoTiveronCS9CheatSheet.TypeExtensibility.ForEachLoopDetectsExtensionGetEnumeratorMethod
{
	public class EnumerableCruise : IEnumerable
	{
		private string PortOfCall1 => "New York";
		private string PortOfCall2 => "Miami";
		private string PortOfCall3 => "Los Angeles";

		public IEnumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		private class Enumerator : IEnumerator
		{
			private EnumerableCruise cruise;

			private int index;

			public Enumerator(EnumerableCruise cruise)
			{
				this.cruise = cruise;
			}

			public object Current => index switch
			{
				0 => cruise.PortOfCall1,
				1 => cruise.PortOfCall2,
				2 => cruise.PortOfCall3,
				_ => throw new System.ArgumentOutOfRangeException()
			};

			public bool MoveNext() => ++index < 3;

			public void Reset() => index = 0;
		}
	}
}
