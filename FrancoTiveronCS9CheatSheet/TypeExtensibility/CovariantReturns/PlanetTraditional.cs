namespace FrancoTiveronCS9CheatSheet.TypeExtensibility.CovariantReturns
{
    public class PlanetTraditional
    {
        public string Name { get; init; }

        /// <summary>
        /// Virtual factory method
        /// </summary>
        /// <returns>Instance of Planet</returns>
        public virtual PlanetTraditional Get() => new PlanetTraditional { Name = "Earth" };
    }

    public class PlaceTraditional : PlanetTraditional
    {
        public string Area { get; init; }

        /// <summary>
        /// Overriden factory method
        /// </summary>
        /// <returns></returns>
        public override PlanetTraditional Get() => new PlaceTraditional { Name = "Earth", Area = "Mediterrnanean Sea" };
    }

    public class CountryTraditional : PlaceTraditional
    {
        public string Capital { get; init; }

        /// <summary>
        /// Overriden factory method
        /// </summary>
        /// <returns></returns>
        public override PlanetTraditional Get() => new CountryTraditional { Name = "Earth", Area = "Oceania", Capital = "Canberra" };
    }
}
