using API.Core.Application.Dto;
using API.Core.Application.Features.CQRS.Commands.CreateProductCommand;
using API.Core.Application.Features.CQRS.Commands.UpdateProductCommand;
using API.Core.Domain;
using AutoMapper;

namespace API.Core.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product,CreateProductCommand>().ReverseMap(); 
            CreateMap<Product,UpdateProductCommand>().ReverseMap();
            CreateMap<Product,ProductsToBeDisplayedinCategoryDto>();
        }
    }

}
