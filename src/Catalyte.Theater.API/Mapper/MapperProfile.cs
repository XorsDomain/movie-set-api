using AutoMapper;
using Catalyte.Theater.Data.Model;
using Catalyte.Theater.DTOs.Movies;
using Catalyte.Theater.DTOs.Rentals;

namespace Catalyte.Theater.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Rental, RentalDTO>().ReverseMap();
            CreateMap<RentedMovie, RentedMoviesDTO>().ReverseMap();
        }
    }
}
