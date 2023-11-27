﻿using Business.Features._Product.CreateProduct;
using Business.Features._Product.RemoveProduct;
using Business.Features.Categories.CreateCategories;
using Business.Features.Categories.GetQueryCategories;
using Business.Features.Categories.UpdateCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Abstractions;

namespace WebApi.Controllers
{
    public sealed class CategoriesController : ApiController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryCommand command, CancellationToken cancellationToken)
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
        public async Task<IActionResult> GelAll(GetCategoriesQueryCommand command, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(response);
        }
    }
}
