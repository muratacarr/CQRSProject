using API.Core.Application.Dto;
using API.Core.Application.Interfaces;
using API.Core.Domain;
using AutoMapper;
using MediatR;

namespace API.Core.Application.Features.CQRS.Queries.CheckUser
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQuery, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;
        private readonly IMapper _mapper;
        public CheckUserQueryHandler(IRepository<AppRole> roleRepository, IRepository<AppUser> userRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var userMap = _mapper.Map<AppUser>(request);
            var user = await _userRepository.GetByFilterAsync(x => x.Username == userMap.Username && x.Password == userMap.Password);
            if (user == null)
            {
                 return new CheckUserResponseDto { IsExist = false };
            }
            else
            {
                var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.Id);
                return new CheckUserResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    IsExist = true,
                    Role = role.Definition
                };
            }
        }
    }
}
