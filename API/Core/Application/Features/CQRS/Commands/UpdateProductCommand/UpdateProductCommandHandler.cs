using API.Core.Application.Interfaces;
using API.Core.Domain;
using AutoMapper;
using MediatR;

namespace API.Core.Application.Features.CQRS.Commands.UpdateProductCommand
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product =_mapper.Map<Product>(request);
            await _repository.UpdateAsync(product);

        }
    }
}
