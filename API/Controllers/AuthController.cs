using API.Core.Application.Features.CQRS.Commands.RegisterUser;
using API.Core.Application.Features.CQRS.Queries.CheckUser;
using API.Infrastructure.Tools;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(RegisterUserCommand command)
        {
            var result=await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Login(CheckUserQuery query)
        {
            var dto = await _mediator.Send(query);
            if (dto.IsExist)
            {
                return Created("", JwtTokenGenerator.GenerateToken(dto));
            }
            else
            {
                return BadRequest("Kullanıcı yada şifre hatalı");
            }
        }
    }
}
