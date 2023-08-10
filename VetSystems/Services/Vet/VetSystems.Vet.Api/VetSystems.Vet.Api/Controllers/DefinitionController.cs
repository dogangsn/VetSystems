﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetSystems.Vet.Application.Features.Customers.Commands;
using VetSystems.Vet.Application.Features.Customers.Queries;
using VetSystems.Vet.Application.Features.Definition.ProductCategory.Commands;
using VetSystems.Vet.Application.Features.Definition.ProductCategory.Queries;
using VetSystems.Vet.Application.Features.Definition.ProductDescription.Queries;

namespace VetSystems.Vet.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefinitionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DefinitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "ProductDescriptionList")]
        public async Task<IActionResult> ProductDescriptionList()
        {
            var command = new ProductDescriptionListQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        #region ProductCategory


        [HttpGet(Name = "ProductCategoryList")]
        public async Task<IActionResult> ProductCategoryList()
        {
            var command = new ProductCategoryListQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(Name = "CreateProductCategories")]
        public async Task<IActionResult> CreateProductCategories([FromBody] CreateProductCategoriesCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        #endregion



    }
}
