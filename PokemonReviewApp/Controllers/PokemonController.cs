using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
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
        private readonly IMapper _mapper;

        public PokemonController(IpokemonRepository pokemonrepository,IMapper mapper)
        {
            _pokemonrepository = pokemonrepository;
            _mapper = mapper;

        }
        // returning all the pokemons in the context
        [HttpGet]
        [ProducesResponseType(200,Type= typeof(IEnumerable<Pokemon>))]   
        public IActionResult GetPokemons() {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonrepository.GetPokemons());    
            if(!ModelState.IsValid) { 
            return BadRequest(ModelState);  
            }
            return Ok(pokemons);
        }
        // returning one pokemon using pokeid
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId)
        {
            if(!_pokemonrepository.PokemonExists(pokeId)) {
                return NotFound();
            }
            var pokemon = _mapper.Map<PokemonDto>(_pokemonrepository.GetPokemon(pokeId));
            if(!ModelState.IsValid) { 
                return BadRequest(ModelState);  
            }
            return Ok(pokemon);
        }
        // getting the pokemon rating using the pokeid
        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonRating(int pokeId) {
            if (!_pokemonrepository.PokemonExists(pokeId))
            {
                return NotFound();  
            }
       
            var rating = _pokemonrepository.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rating);

        }



    }
}
