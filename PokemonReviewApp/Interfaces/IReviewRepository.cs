using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews { get; }
        Review GetReview(int reviewId);   
        ICollection<Review> GetReviewOfAPokemon(int pokeId);
        bool ReviewExists (int reviewId);

    }
}
