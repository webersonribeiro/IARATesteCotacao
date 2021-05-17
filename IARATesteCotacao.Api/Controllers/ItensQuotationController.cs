using IARATesteCotacao.Business.ItensQuotationArea.UseCases.AddItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.GetItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.ListItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.RemoveItensQuotation;
using IARATesteCotacao.Business.ItensQuotationArea.UseCases.UpdateItensQuotation;
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
    public class ItensQuotationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItensQuotationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ItensQuotationController>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Get(long QuotationId) => await _mediator.Send(new ListItensQuotationCommand { QuotationId = QuotationId });

        // GET api/<ItensQuotationController>/5
        [HttpGet("{QuotationId}/{ProductId}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Get(long QuotationId, int ProductId) => await _mediator.Send(new GetItensQuotationCommand { QuotationId = QuotationId, ProductId = ProductId });

        // POST api/<ItensQuotationController>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Post(AddItensQuotationCommand command) => await _mediator.Send(command);

        // PUT api/<ItensQuotationController>/5
        [HttpPut("{QuotationId}/{ProductId}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Put(UpdateItensQuotationCommand command, long QuotationId, int ProductId)
        {
            command.QuotationId = QuotationId;
            command.ProductId = ProductId;
            return await _mediator.Send(command);
        }

        // DELETE api/<ItensQuotationController>/5
        [HttpDelete("{QuotationId}/{ProductId}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Delete(long QuotationId, int ProductId) => await _mediator.Send(new RemoveItensQuotationCommand
        { QuotationId = QuotationId, ProductId = ProductId });
    }
}
