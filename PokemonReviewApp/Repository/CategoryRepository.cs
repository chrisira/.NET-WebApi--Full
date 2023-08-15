using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : IcategoryRepository
    {
        public bool CategoriesExists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
