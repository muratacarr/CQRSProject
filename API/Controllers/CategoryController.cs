using API.Core.Application.Dto;
using API.Core.Application.Features.CQRS.Queries.CategoryWithProducts;
using API.Core.Application.Features.CQRS.Queries.CheckUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWithProducts(int id)
        {
            var result = await _mediator.Send(new CategoryWithProductsQuery(id));
            return Ok(result);
        }
        
        
    }
}
