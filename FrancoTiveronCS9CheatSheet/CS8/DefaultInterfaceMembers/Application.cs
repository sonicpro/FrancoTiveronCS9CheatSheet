namespace FrancoTiveronCS9CheatSheet.CS8.DefaultInterfaceMembers
{
    public class ApplicationV1 : OldWayOfInterfaceAugmenting.ILibrary
    {
        public int Increment(int i) => ++i;
    }

    public class ApplicationV2 : OldWayOfInterfaceAugmenting.ILibrary
    {
        public int Increment(int i) => ++i;

        public int Decrement(int i) => --i;
    }

    // This class is the same as the ApplicatoinV1. However it implements CS8WayOfInterfaceAurmenting.ILibrary interface, which has 2 members.
    public class Application: CS8WayOfInterfaceAugmenting.ILibrary
    {
        public int Increment(int i) => ++i;
    }
}
