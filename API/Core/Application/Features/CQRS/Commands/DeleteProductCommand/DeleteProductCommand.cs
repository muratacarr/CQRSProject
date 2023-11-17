using MediatR;

namespace API.Core.Application.Features.CQRS.Commands.DeleteProductCommand
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
