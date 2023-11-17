using API.Core.Application.Dto;
using API.Core.Application.Enums;
using API.Core.Application.Interfaces;
using API.Core.Domain;
using AutoMapper;
using MediatR;

namespace API.Core.Application.Features.CQRS.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, CreatedUser>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IRepository<AppUser> appUserRepository, IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _mapper = mapper;
        }

        async Task<CreatedUser> IRequestHandler<RegisterUserCommand, CreatedUser>.Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser>(request);
            var user = await _appUserRepository.CreateAsync(appUser);
            return _mapper.Map<CreatedUser>(user);

        }
    }
}
