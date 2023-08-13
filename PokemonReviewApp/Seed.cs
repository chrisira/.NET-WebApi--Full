using PokemonReviewApp.Data;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly ApplicationDbContext dataContext;
        public Seed(ApplicationDbContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>()
        {
            new PokemonOwner()
            {
                Pokemon = new Pokemon()
                {
                    Name = "Pikachu",
                    BirthDate = new DateTime(1903,1,1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory { Category = new Category() { Name = "Electric"}}
                    },
                    Reviews = new List<Review>()
                    {
                        new Review { Title="Pikachu",Text = "Pikachu is the best pokemon, because it is electric", Rating = 5,
                        Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                        new Review { Title="Pikachu", Text = "Pikachu is the best a killing rocks", Rating = 5,
                        Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                        new Review { Title="Pikachu",Text = "Pikachu, Pikachu, Pikachu", Rating = 1,
                        Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                    }
                },
                Owner = new Owner()
                {
                    FirstName = "Jack",
                    LastName = "London",
                    Gym = "Brock's Gym",
                    Country = new Country()
                    {
                        Name = "Kanto"
                    }
                }
            },
            new PokemonOwner()
            {
                Pokemon = new Pokemon()
                {
                    Name = "Squirtle",
                    BirthDate = new DateTime(1903,1,1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory { Category = new Category() { Name = "Water"}}
                    },
                    Reviews = new List<Review>()
                    {
                        new Review { Title= "Squirtle", Text = "Squirtle is the best pokemon, because it is water", Rating = 5,
                        Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                        new Review { Title= "Squirtle",Text = "Squirtle is the best at battling in water", Rating = 5,
                        Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                        new Review { Title= "Squirtle", Text = "Squirtle, Squirtle, Squirtle", Rating = 1,
                        Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                    }
                },
                Owner = new Owner()
                {
                    FirstName = "Harry",
                    LastName = "Potter",
                    Gym = "Misty's Gym",
                    Country = new Country()
                    {
                        Name = "Saffron City"
                    }
                }
            },
            new PokemonOwner()
            {
                Pokemon = new Pokemon()
                {
                    Name = "Venusaur",
                    BirthDate = new DateTime(1903,1,1),
                    PokemonCategories = new List<PokemonCategory>()
                    {
                        new PokemonCategory { Category = new Category() { Name = "Leaf"}}
                    },
                    Reviews = new List<Review>()
                    {
                        new Review { Title="Venusaur",Text = "Venusaur is the best pokemon, because it is a grass type", Rating = 5,
                        Reviewer = new Reviewer(){ FirstName = "Teddy", LastName = "Smith" } },
                        new Review { Title="Venusaur",Text = "Venusaur is the best at harnessing nature's power", Rating = 5,
                        Reviewer = new Reviewer(){ FirstName = "Taylor", LastName = "Jones" } },
                        new Review { Title="Venusaur",Text = "Venusaur, Venusaur, Venusaur", Rating = 1,
                        Reviewer = new Reviewer(){ FirstName = "Jessica", LastName = "McGregor" } },
                    }
                },
                Owner = new Owner()
                {
                    FirstName = "Ash",
                    LastName = "Ketchum",
                    Gym = "Ash's Gym",
                    Country = new Country()
                    {
                        Name = "Pallet Town"
                    }
                }
            }
        };

                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }




    }
}