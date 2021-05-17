using IARATesteCotacao.Business.ProductsArea.UseCases.AddProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.GetProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.ListProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.RemoveProduct;
using IARATesteCotacao.Business.ProductsArea.UseCases.UpdateProduct;
using IARATesteCotacao.Business.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IARATesteCotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Get() => await _mediator.Send(new ListProductCommand());

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Get(int id) => await _mediator.Send(new GetProductCommand() { Id = id });

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Post(AddProductCommand command) => await _mediator.Send(command);

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Put(UpdateProductCommand command, int id) => await _mediator.Send(new UpdateProductCommand { Id = id, Name = command.Name, Status = command.Status });

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ApiResult> Delete(int id) => await _mediator.Send(new RemoveProductCommand { Id = id });
    }
}
