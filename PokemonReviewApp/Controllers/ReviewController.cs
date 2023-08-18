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
    public class ReviewController:ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository,IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
                
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(reviews);
        }
        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }
            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(review);
        }
        [HttpGet("/pokemon{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewForAPokemon(int pokeId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewOfAPokemon(pokeId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromBody] ReviewDto reviewCreate)
        {
            //checking if the reviewCreate is null
            if (reviewCreate == null)
            {
                return BadRequest(ModelState);
            }

            // cheking if the Review name exists
            var review = _reviewRepository.GetReviews()
                .Where(c => c.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd().ToUpper()).FirstOrDefault();

            if (review != null)
            {
                ModelState.AddModelError("", "review already exists");
                return StatusCode(422, ModelState);
            }

            // checking if data is valid

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reviewMap = _mapper.Map<Review>(reviewCreate);

            if (!_reviewRepository.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while trying to save review");
                return StatusCode(500, ModelState);
            }

            return Ok("review saved successfully");

        }
    }
}
