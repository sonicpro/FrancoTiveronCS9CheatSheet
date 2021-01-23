using Xunit;
using Cs9CheatSheet.Immutability.Records;

namespace XUnitTests
{
    public class ActorPositionalRecordTests
    {
        [Fact]
        public void TestImmutableRecords()
        {
            var juliaRoberts = new ActorInMovie("Julia", "Tess", "Roberts");

            // First option to get the immutable object copy - to use the generated copy constructor expicitly.
            var juliaRobertsCopy1 = juliaRoberts.Copy();
            Assert.Equal(juliaRoberts, juliaRobertsCopy1);

            // Second option to get the immutable object copy - to use "with" expression without parameters.
            var juliaRobertsCopy2 = juliaRoberts with { };
            Assert.Equal(juliaRoberts, juliaRobertsCopy2);

            // "With" expression can be used to get a modified copy of the record.
            var juliaRobertsPerformingHerself = juliaRoberts with { CharacterName = "Julia Roberts" };
            Assert.NotEqual(juliaRoberts, juliaRobertsPerformingHerself);

            // "public void Deconstruct(out <type> prop1, out <type> prop2, ...)" method is generated for records automatically.
            // For classes you can create such a method to support deconstructing.
            var (firstName, _, lastName) = juliaRoberts;
            var (firstNameOfJuliaPerformingHerself, _, lastNameOfJuliaPerformingHerself) = juliaRobertsPerformingHerself;
            Assert.Equal((firstName, lastName), (firstNameOfJuliaPerformingHerself, lastNameOfJuliaPerformingHerself));
        }
    }
}
