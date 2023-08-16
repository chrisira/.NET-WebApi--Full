using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IreviewerRepository
    {
        ICollection<Reviewer> GetReviewers();

        Reviewer GetReviewer(int reviewerId);   
        ICollection<Reviewer> GetReviewsByReviewer(int reviewerId);
        bool ReviewExists(int reviewerId);  

    }
}
