using API.Core.Application.Dto;
using MediatR;

namespace API.Core.Application.Features.CQRS.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<List<ProductDto>>
    {
    }
}
