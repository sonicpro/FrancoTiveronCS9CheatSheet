namespace FrancoTiveronCS9CheatSheet.CS8.DefaultInterfaceMembers
{
    namespace OldWayOfInterfaceAugmenting
    {
        public interface ILibrary
        {
            int Increment(int i);
        }

        // Old way of the interface augmenting - imposes a new interface.
        public interface ILibraryV2 : ILibrary
        {
            int Decrement(int i);
        }
    }


    namespace CS8WayOfInterfaceAugmenting
    {
        // Declaring the new member as having the default implementation does not break the interface compatibility.
        // Users that only implement the Increment member do not have to rewrite their code to conform to the updated interface.
        public interface ILibrary
        {
            int Increment(int i);

            // Users that 
            int Decrement(int i) => --i;
        }
    }
}
