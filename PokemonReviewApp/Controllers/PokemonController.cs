using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController:ControllerBase
    {
        private readonly IpokemonRepository _pokemonrepository; 
        public PokemonController(IpokemonRepository pokemonrepository)
        {
            _pokemonrepository = pokemonrepository;
                
        }
        [HttpGet]
        [ProducesResponseType(200,Type= typeof(IEnumerable<Pokemon>))]   
        public IActionResult GetPokemons() {
            var pokemons = _pokemonrepository.GetPokemons();    
            if(!ModelState.IsValid) { 
            return BadRequest(ModelState);  
            }
            return Ok(pokemons);
        }
    }
}
