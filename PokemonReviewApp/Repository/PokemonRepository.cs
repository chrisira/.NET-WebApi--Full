using Microsoft.EntityFrameworkCore.Diagnostics;
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
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();  
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();  
        }

        public decimal GetPokemonRating(int pokeid)
        {
            var review = _context.Reviews.Where(p => p.Id == pokeid);  
            
            if(review.Count() <= 0) {
                return 0;
            }
            return ((decimal)review.Sum(r=> r.Rating)) / review.Count();    
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList(); 
        }

        public bool PokemonExists(int pokeid)
        {
            return _context.Pokemon.Any(p=> p.Id == pokeid);

        }


        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault(); 
            var category = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

            var PokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };

            _context.Add(PokemonOwner);

            var PokemonCategory = new PokemonCategory()
            {
                Category = category,
                Pokemon = pokemon,
            };
            _context.Add(PokemonCategory);

            _context.Add(pokemon);

            return save();

        }


        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
