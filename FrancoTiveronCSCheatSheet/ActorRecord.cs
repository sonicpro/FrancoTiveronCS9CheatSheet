namespace Cs9CheatSheet.Immutability.Records
{
    // Example of mutable record (properties are with public setters.
    public record ActorRecord
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
