using IARATesteCotacao.Business.QuotationsArea.UseCases.AddQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.GetQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.ListQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.RemoveQuotation;
using IARATesteCotacao.Business.QuotationsArea.UseCases.UpdateQuotation;
using IARATesteCotacao.Business.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IARATesteCotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {

        private readonly IMediator _mediator;

        public QuotationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<QuotationController>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Get() => await _mediator.Send(new ListQuotationCommand());

        // GET api/<QuotationController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Get(int id) => await _mediator.Send(new GetQuotationCommand() { Id = id });

        // POST api/<QuotationController>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Post(AddQuotationCommand command) => await _mediator.Send(command);

        // PUT api/<QuotationController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Put(UpdateQuotationCommand command, int id)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        // DELETE api/<QuotationController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Delete(int id) => await _mediator.Send(new RemoveQuotationCommand { Id = id });
    }
}
