using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    public class CountryController : ICountryRepository
    {
        public bool countryExists(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Country> Getcountries()
        {
            throw new NotImplementedException();
        }

        public Country GetCountry(int id)
        {
            throw new NotImplementedException();
        }

        public Country GetCountryByOwner(int ownerId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Owner> GetOwnersFromCountry(int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
