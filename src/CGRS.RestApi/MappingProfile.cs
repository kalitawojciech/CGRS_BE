using System.Linq;
using AutoMapper;
using CGRS.Application.Dtos.Categories;
using CGRS.Application.Dtos.GameComments;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Dtos.GamesMark;
using CGRS.Application.Dtos.Users;
using CGRS.Domain.Entities;

namespace CGRS.RestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Game, GameInfoResponse>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.GameMarkResponse, opt => opt.MapFrom(src => src.GamesMarks.FirstOrDefault()));
            CreateMap<Game, GamePopulatedResponse>()
                .ForMember(dest => dest.UserGameMark, opt => opt.MapFrom(src => src.GamesMarks.FirstOrDefault()));
            CreateMap<Game, GameNameResponse>();

            CreateMap<Category, CategoryInfoResponse>();
            CreateMap<Category, CategoryPopulatedResponse>();

            CreateMap<User, UserInfoResponse>();

            CreateMap<GamesMark, GameMarkResponse>()
                .ForMember(dest => dest.AverageScore, opt => opt.MapFrom(src => src.Score));

            CreateMap<GamesComment, GameCommentResponse>();
        }
    }
}
