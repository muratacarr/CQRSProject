using MediatR;

namespace API.Core.Application.Features.CQRS.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest
    {
        public UpdateProductCommand(int id, string name, int stock, decimal price, int categoryId)
        {
            Id = id;
            Name = name;
            Stock = stock;
            Price = price;
            CategoryId = categoryId;
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
