using API.Core.Application.Dto;
using MediatR;

namespace API.Core.Application.Features.CQRS.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CreateProductCommand(string name, int stock, decimal price, int categoryId)
        {
            Name = name;
            Stock = stock;
            Price = price;
            CategoryId = categoryId;
        }


    }
}
