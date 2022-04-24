using AutoMapper;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Movies;

namespace Catalyte.Apparel.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}
