using Business.Features._Product.CreateProduct;
using Business.Features._Product.GetProductQuery;
using Business.Features._Product.RemoveProduct;
using Business.Features._Product.UpdateProduct;
using Business.Features.Categories.CreateCategories;
using Business.Features.Categories.GetQueryCategories;
using Business.Features.Categories.UpdateCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;

namespace WebApi.Controllers
{
    public sealed class ProductController : ApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Remove(RemoveProductCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> GelAll(GetProductQueryCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
