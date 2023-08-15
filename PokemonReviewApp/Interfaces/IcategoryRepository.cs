using PokemonReviewApp.Models;
using System.ComponentModel;

namespace PokemonReviewApp.Interfaces
{
    public interface IcategoryRepository
    {
        ICollection<Category>GetCategories();
        Category GetCategory(int id);  
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);   
        bool CategoriesExists(int id);  
    }
}
