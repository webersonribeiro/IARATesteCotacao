using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, ApiResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetProductValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };
                        
            var productResult = await _productRepository.GetByIdAsync(request.Id);
            return new ApiResult<Product>() { ResultCode = StatusCodes.Status200OK, Data = productResult };
        }
    }
}
