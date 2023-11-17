using API.Core.Application.Dto;
using MediatR;

namespace API.Core.Application.Features.CQRS.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ProductDto>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
