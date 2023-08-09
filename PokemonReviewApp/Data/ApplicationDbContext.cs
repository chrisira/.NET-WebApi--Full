using Microsoft.EntityFrameworkCore;

namespace PokemonReviewApp.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

                
        }
    }
}

