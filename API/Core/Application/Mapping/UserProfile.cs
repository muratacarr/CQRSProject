using API.Core.Application.Dto;
using API.Core.Application.Features.CQRS.Commands.RegisterUser;
using API.Core.Application.Features.CQRS.Queries.CheckUser;
using API.Core.Domain;
using AutoMapper;

namespace API.Core.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<AppUser, RegisterUserCommand>().ReverseMap();
            CreateMap<AppUser, CreatedUser>();
            CreateMap<AppUser,CheckUserResponseDto>().ReverseMap();
            CreateMap<AppUser,CheckUserQuery>().ReverseMap();
        }

    }
}
