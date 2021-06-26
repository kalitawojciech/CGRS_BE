using AutoMapper;
using CGRS.Application.Dtos.Categories;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Dtos.Users;
using CGRS.Domain.Entities;

namespace CGRS.RestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameInfoResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<Game, GamePopulatedResponse>();

            CreateMap<Category, CategoryInfoResponse>();
            CreateMap<Category, CategoryPopulatedResponse>();

            CreateMap<User, UserInfoResponse>();
        }
    }
}
