using API.Core.Application.Features.CQRS.Commands.CreateProductCommand;
using API.Core.Application.Features.CQRS.Commands.DeleteProductCommand;
using API.Core.Application.Features.CQRS.Commands.UpdateProductCommand;
using API.Core.Application.Features.CQRS.Queries.GetAllProducts;
using API.Core.Application.Features.CQRS.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var createdProduct = await _mediator.Send(command);
            return Ok(createdProduct);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
