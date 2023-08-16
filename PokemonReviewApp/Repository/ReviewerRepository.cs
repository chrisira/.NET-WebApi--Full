using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IreviewerRepository
    {
        public Reviewer GetReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Reviewer> GetReviewsByReviewer(int reviewerId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(int reviewerId)
        {
            throw new NotImplementedException();
        }
    }
}
