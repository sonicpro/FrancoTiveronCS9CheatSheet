namespace Cs9CheatSheet.Immutability.Records
{
    // Example if immutable record (init-only properties).
    public record ActorPositionalRecord(string FirstName, string LastName);

    // Records can be derived.
    public record ActorInMovie(string FirstName, string CharacterName, string LastName) : ActorPositionalRecord(FirstName, LastName)
    {
        // Adding method for explicitly using the compiler-generated copy constructor.
        public ActorInMovie Copy() => new ActorInMovie(this);
    }
}
