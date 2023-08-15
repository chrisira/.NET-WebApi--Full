using AutoMapper;
using PokemonReviewApp.Dtos;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Helpers
{
    public class MappingProfiles:Profile 
    {
        public MappingProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<Review, ReviewDto>();

        }
    }
}
