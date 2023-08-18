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
    public class CountryController:ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository,IMapper mapper) {
            _countryRepository = countryRepository;
            _mapper = mapper;
        
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(countries);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.countryExists(countryId))
            {
                return NotFound();
            }
            
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(country);

        }
        [HttpGet("owners/{ownerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        [ProducesResponseType(400)]


        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(_countryRepository.GetCountryByOwner(ownerId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(country);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            //checking if the country is null
            if (countryCreate == null)
            {
                return BadRequest(ModelState);
            }

            // cheking if the category name exists
            var country = _countryRepository.GetCountries()
                .Where(c => c.Name.Trim().ToUpper() == countryCreate.Name.TrimEnd().ToUpper()).FirstOrDefault();

            if (country != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            // checking if data is valid

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var countryMap = _mapper.Map<Country>(countryCreate);

            if (!_countryRepository.CreateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while trying to save country");
                return StatusCode(500, ModelState);
            }

            return Ok("Country saved successfully");

        }
        [HttpPut("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult UpdateCategory(int countryId, [FromBody] CountryDto updateCountry)
        {

            //checking if the updateCountry is null
            if (updateCountry == null)
            {
                return BadRequest(ModelState);
            }
            if (countryId != updateCountry.Id)
            {
                return BadRequest(ModelState);

            }

            if (!_countryRepository.countryExists(countryId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var countryMap = _mapper.Map<Country>(updateCountry);

            if (!_countryRepository.UpdateCountry(countryMap))
            {
                ModelState.AddModelError("", "Something went wrong while trying to Update Country");
                return StatusCode(500, ModelState);
            }
            return NoContent();



        }
        [HttpDelete("{countryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult DeleteCountry(int countryId)
        {
            if (!_countryRepository.countryExists(countryId))
            {
                return NotFound();
            }
            var countryToDelete = _countryRepository.GetCountry(countryId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_countryRepository.DeleteCountry(countryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while trying to delete country");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }


    }
}
