namespace FrancoTiveronCS9CheatSheet.TypeExtensibility.CovariantReturns
{
    // In CS 9 we can change the overriden method signatures so that to use covariant return types.
    public class PlanetNewWay
    {
        public string Name { get; init; }

        /// <summary>
        /// Virtual factory method
        /// </summary>
        /// <returns>Instance of Planet</returns>
        public virtual PlanetNewWay Get() => new PlanetNewWay { Name = "Earth" };
    }

    public class PlaceNewWay : PlanetNewWay
    {
        public string Area { get; init; }

        /// <summary>
        /// Overriden factory method
        /// </summary>
        /// <returns></returns>
        public override PlaceNewWay Get() => new PlaceNewWay { Name = "Earth", Area = "Mediterrnanean Sea" };
    }

    public class CountryNewWay : PlaceNewWay
    {
        public string Capital { get; init; }

        /// <summary>
        /// Overriden factory method
        /// </summary>
        /// <returns></returns>
        public override CountryNewWay Get() => new CountryNewWay { Name = "Earth", Area = "Oceania", Capital = "Canberra" };
    }
}
