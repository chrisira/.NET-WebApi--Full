using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController:ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countrRepository;

        public OwnerController(IOwnerRepository ownerRepository,ICountryRepository countryRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _countrRepository = countryRepository;
            
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }
            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owner);
        }

        [HttpGet("{ownerId}/pokemon")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
            {
                return NotFound();
            }
            var pokemons = _mapper.Map<List<PokemonDto>>(_ownerRepository.GetPokemonByOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(pokemons);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOwner([FromQuery] int countryId, [FromBody] OwnerDto ownerCreate)
        {
            //checking if the Owner is null
            if (ownerCreate == null)
            {
                return BadRequest(ModelState);
            }

            // cheking if the owner name exists
            var owner = _ownerRepository.GetOwners()
                .Where(c => c.LastName.Trim().ToUpper() == ownerCreate.LastName.TrimEnd().ToUpper()).FirstOrDefault();

            if (owner != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            // checking if data is valid

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownerMap = _mapper.Map<Owner>(ownerCreate);

            ownerMap.Country = _countrRepository.GetCountry(countryId); 

            if (!_ownerRepository.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while trying to save Owner");
                return StatusCode(500, ModelState);
            }

            return Ok("Owner saved successfully");

        }
    }

    }




    

