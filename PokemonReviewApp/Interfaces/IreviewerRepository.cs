using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IreviewerRepository
    {
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByReviewer(int reviewerId);
        bool ReviewerExists(int reviewerId);

    }
}
