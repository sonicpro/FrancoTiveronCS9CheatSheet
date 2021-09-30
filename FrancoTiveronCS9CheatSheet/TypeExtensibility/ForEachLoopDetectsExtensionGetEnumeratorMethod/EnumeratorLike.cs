// The class returned by GetEnumerator extension method must satisfy the following conditions:
// 1) Have Current property. The type of the property does not matter.
// 2) Have MoveNext() method. The method returns boolean just like MoveNext() in IEnumerator and IEnumerator<T>
namespace FrancoTiveronCS9CheatSheet.TypeExtensibility.ForEachLoopDetectsExtensionGetEnumeratorMethod
{
	public class EnumeratorLike
	{
		private NonEnumerableCruise cruise;

		private int index = 0;

		public EnumeratorLike(NonEnumerableCruise cruise)
		{
			this.cruise = cruise;
		}

		public UsPortsEnum Current => index switch
		{
			0 => cruise.PortOfCall1,
			1 => cruise.PortOfCall2,
			2 => cruise.PortOfCall3,
			_ => throw new System.ArgumentOutOfRangeException()
		};

		public bool MoveNext() => ++index < 3;
	}
}
