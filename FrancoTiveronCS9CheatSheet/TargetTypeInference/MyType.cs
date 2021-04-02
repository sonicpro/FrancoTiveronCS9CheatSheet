namespace FrancoTiveronCS9CheatSheet.TargetTypeInference
{
	// Short-hand record declaration.
	// This declares "MyType" record with "Value" public init-only autoproperty and the paremeterized constructor with the default parameter of 0.
	// For the records with 2+ properties Deconstruct method is also created by the compiler.
	public record MyDataType(int Value = 0);
	
}
