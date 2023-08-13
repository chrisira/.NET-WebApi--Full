using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class PokemonRepository : IpokemonRepository
    {
        private readonly ApplicationDbContext _context; 
        public PokemonRepository(ApplicationDbContext context)
        {
            _context = context;
                
        }

        public Pokemon GetPokemon(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemon(string name)
        {
            throw new NotImplementedException();
        }

        public decimal GetPokemonRating(int pokeid)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList(); 
        }

        public bool PokemonExists(int pokeid)
        {
            throw new NotImplementedException();
        }
    }
}
