using System.Linq;
using AutoMapper;
using CGRS.Application.Dtos;
using CGRS.Application.Dtos.Categories;
using CGRS.Application.Dtos.GameComments;
using CGRS.Application.Dtos.Games;
using CGRS.Application.Dtos.GamesMark;
using CGRS.Application.Dtos.Tags;
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
                .ForMember(dest => dest.GameMarkResponse, opt => opt.MapFrom(src => src.GamesMarks.FirstOrDefault()))
                .ForMember(dest => dest.GameTags, opt => opt.MapFrom(src => src.GamesTags.Select(x => x.Tag).ToList()));
            CreateMap<Game, GamePopulatedResponse>()
                .ForMember(dest => dest.UserGameMark, opt => opt.MapFrom(src => src.GamesMarks.FirstOrDefault()))
                .ForMember(dest => dest.GameTags, opt => opt.MapFrom(src => src.GamesTags.Select(x => x.Tag).ToList()));
            CreateMap<Game, GameNameResponse>();

            CreateMap<Category, CategoryInfoResponse>();
            CreateMap<Category, CategoryPopulatedResponse>();

            CreateMap<User, UserInfoResponse>();
            CreateMap<User, UserFullInfoResponse>();

            CreateMap<GamesMark, GameMarkResponse>()
                .ForMember(dest => dest.AverageScore, opt => opt.MapFrom(src => src.Score));

            CreateMap<GamesComment, GameCommentResponse>();

            CreateMap<Tag, TagInfoResponse>();

            CreateMap(typeof(PagedEntity<>), typeof(PagedResponse<>));
        }
    }
}
