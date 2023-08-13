using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IpokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

        //getting one pokemon by using id
        Pokemon GetPokemon(int id);
        // geting one pokemon by using a name
        Pokemon GetPokemon(string name);
        // gettting the pokemon rating
        decimal GetPokemonRating(int pokeid);
        // checking whether the pokemon exists
        bool PokemonExists(int pokeid); 
             
       
    }
}
