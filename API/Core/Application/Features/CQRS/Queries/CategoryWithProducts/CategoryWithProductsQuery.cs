using API.Core.Application.Dto;
using MediatR;

namespace API.Core.Application.Features.CQRS.Queries.CategoryWithProducts
{
    public class CategoryWithProductsQuery:IRequest<CategoryWithProductsDto>
    {
        public int Id { get; set; }

        public CategoryWithProductsQuery(int id)
        {
            Id = id;
        }
    }
}
