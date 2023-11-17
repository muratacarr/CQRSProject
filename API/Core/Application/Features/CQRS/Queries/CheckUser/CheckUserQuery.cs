using API.Core.Application.Dto;
using MediatR;

namespace API.Core.Application.Features.CQRS.Queries.CheckUser
{
    public class CheckUserQuery:IRequest<CheckUserResponseDto>
    {
        public CheckUserQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
