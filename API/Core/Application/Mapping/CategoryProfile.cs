using API.Core.Application.Dto;
using API.Core.Domain;
using AutoMapper;

namespace API.Core.Application.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category,CategoryWithProductsDto>().ReverseMap();
        }
    }
}
