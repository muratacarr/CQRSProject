using API.Core.Application.Dto;
using MediatR;

namespace API.Core.Application.Features.CQRS.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<CreatedUser>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int AppRoleId { get; set; }
    }
}
