using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner GetOwner(int ownerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Owner> GetOwnerOfAPokemon(int pokeid)
        {
            throw new NotImplementedException();
        }

        public ICollection<Owner> GetOwners()
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
        {
            throw new NotImplementedException();
        }

        public bool OwnerExists(int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
