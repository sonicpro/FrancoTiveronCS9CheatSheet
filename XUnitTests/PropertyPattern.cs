using FrancoTiveronCS9CheatSheet.CS8.Pattern_Matching.Property_Pattern;
using Xunit;

namespace XUnitTests
{
    public class PropertyPattern
    {
        [Fact]
        public void TestProperyPatternAgainstOldStyleCode()
        {
            ZonalClient[] clients = new[]
            {
                new ZonalClient { Purchases = 141, Zone = Zones.Z2, Company = Companies.C1 },
                new ZonalClient { Purchases = 14, Zone = Zones.Z3, Company = Companies.C2 },
                new ZonalClient { Purchases = 400, Zone = Zones.Z2, Company = Companies.C3 },
                new ZonalClient { Purchases = 600, Zone = Zones.Z3, Company = Companies.C2 },
                new ZonalClient { Purchases = 55, Zone = Zones.Z1, Company = Companies.C1 }
            };
            var applier = new DiscountApplier();
            Assert.All(clients, c => Assert.Equal(applier.OldStyle(c), applier.PropertyPattern(c)));
        }
    }
}
