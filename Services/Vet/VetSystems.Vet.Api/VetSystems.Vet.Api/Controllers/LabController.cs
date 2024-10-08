﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VetSystems.Vet.Application.Features.Customers.Queries;
using VetSystems.Vet.Application.Features.FileManager.Queries;
using VetSystems.Vet.Application.Features.Lab.Queries;

namespace VetSystems.Vet.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LabController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "CustomersLabList")]
        public async Task<IActionResult> CustomersLabList()
        {
            var command = new CustomersLabListQuery();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost(Name = "GetLabDocumentById")]
        public async Task<IActionResult> GetLabDocumentById([FromBody] GetLabDocumentByIdQuery command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
