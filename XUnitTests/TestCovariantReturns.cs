using System;
using Xunit;
using FrancoTiveronCS9CheatSheet.TypeExtensibility.CovariantReturns;

namespace XUnitTests
{
    public class TestCovariantReturns
    {
        [Fact]
        public static void TestTraditionalHierarchy()
        {
            var (planet, place, country) = (new PlanetTraditional(), new PlaceTraditional(), new CountryTraditional());

            var targetPlace = place.Get();
            string area = ((PlaceTraditional)targetPlace).Area;            // Cast is required

            var targetCountry = country.Get();
            area = ((CountryTraditional)targetCountry).Area;               // Cast is required
            string capital = ((CountryTraditional)targetCountry).Capital;  // Cast is required

            // Invalid downcasts while using traditional hierarchy.
            Assert.Throws<InvalidCastException>(() => (PlaceTraditional)planet.Get());
            Assert.Throws<InvalidCastException>(() => (CountryTraditional)planet.Get());
            Assert.Throws<InvalidCastException>(() => (CountryTraditional)place.Get());
        }

        [Fact]
        public static void TestNewWayHierarchy()
        {
            var (planet, place, country) = (new PlanetNewWay(), new PlaceNewWay(), new CountryNewWay());

            var targetPlace = place.Get();
            string area = targetPlace.Area;

            var targetCountry = country.Get();
            area = targetCountry.Area;
            string capital = targetCountry.Capital;

            // Invalid downcasts while using the new way method overriding are thrown the same as in the traditional hierarchy.
            Assert.Throws<InvalidCastException>(() => (PlaceNewWay)planet.Get());
            Assert.Throws<InvalidCastException>(() => (CountryNewWay)planet.Get());
            Assert.Throws<InvalidCastException>(() => (CountryNewWay)place.Get());
        }
    }
}
