namespace FrancoTiveronCS9CheatSheet.TypeExtensibility.ForEachLoopDetectsExtensionGetEnumeratorMethod
{
	// Add GetEnumerator extension method to NonEnumerableCruise class.
	public static class NonEnumerableCruiseExtensions
	{
		public static EnumeratorLike GetEnumerator(this NonEnumerableCruise cruise) => new EnumeratorLike(cruise);
	}
}
