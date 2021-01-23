using Xunit;
using Cs9CheatSheet.Immutability.Records;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTests
{
    public class ActorRecordUnitTests
    {
        [Fact]
        public void TestActorRecords()
        {
            var baldwinActor1 = new ActorRecord { FirstName = "Alec", LastName = "Baldwin" };
            var baldwinActor2 = new ActorRecord { FirstName = "Alec", LastName = "Baldwin" };
            // Class semantic - two objects, three references.
            var baldwinActorClone = baldwinActor1;

            // Struct sementic - compiler generates value comparison code for records.
            Assert.Equal(baldwinActor1, baldwinActor2);

            // Methods that use GetHashCode() and Equals() methods behave like with structs or value types.
            List<ActorRecord> actors = new List<ActorRecord> { baldwinActor1, baldwinActor2 };
            Assert.Single(actors.Distinct());

            baldwinActor1.FirstName = "William";
            Assert.Equal("William", baldwinActorClone.FirstName);
            // Still value comparison is performed for records.
            Assert.NotEqual(baldwinActor1, baldwinActor2);
            Assert.Equal(baldwinActor1, baldwinActorClone);
        }
    }
}
