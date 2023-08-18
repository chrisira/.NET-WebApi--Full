using AutoMapper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IpokemonRepository _pokemonrepository;
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public PokemonController(IpokemonRepository pokemonrepository,
            IReviewRepository reviewRepository, IcategoryRepository categoryRepository,

            IMapper mapper)
        {
            _pokemonrepository = pokemonrepository;
            _mapper = mapper;
            _reviewRepository = reviewRepository;

        }
        // returning all the pokemons in the context
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons() {
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonrepository.GetPokemons());
            if (!ModelState.IsValid) {
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
            if (!_pokemonrepository.PokemonExists(pokeId)) {
                return NotFound();
            }
            var pokemon = _mapper.Map<PokemonDto>(_pokemonrepository.GetPokemon(pokeId));
            if (!ModelState.IsValid) {
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto pokemonCreate)
        {
            //checking if the Pokemon is null
            if (pokemonCreate == null)
            {
                return BadRequest(ModelState);
            }

            // cheking if the pokemon name exists
            var pokemon = _pokemonrepository.GetPokemons()
                .Where(c => c.Name.Trim().ToUpper() == pokemonCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (pokemon != null)
            {
                ModelState.AddModelError("", "Pokemon already exists");
                return StatusCode(422, ModelState);
            }

            // checking if data is valid

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);



            if (!_pokemonrepository.CreatePokemon(ownerId, catId, pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while trying to save Pokemon");
                return StatusCode(500, ModelState);
            }

            return Ok("Pokemon saved successfully");

        }
        [HttpPut("{pokeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult UpdatePokemon(int pokeId, 
            [FromQuery] int ownerId,
            [FromQuery] int catId,
            [FromBody] PokemonDto updatePokemon)
        {

            //checking if the updatePokemon is null
            if (updatePokemon == null)
            {
                return BadRequest(ModelState);
            }
            if (pokeId != updatePokemon.Id)
            {
                return BadRequest(ModelState);

            }

            if (!_pokemonrepository.PokemonExists(pokeId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var pokemonMap = _mapper.Map<Pokemon>(updatePokemon);

            if (!_pokemonrepository.UpdatePokemon(ownerId,catId,pokemonMap))
            {
                ModelState.AddModelError("", "Something went wrong while trying to Update Pokemon");
                return StatusCode(500, ModelState);
            }
            return NoContent();



        }



    }
}
