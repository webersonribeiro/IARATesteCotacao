using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.UpdateProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ApiResult>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var productResult = await _productRepository.GetByIdAsync(request.Id);
            productResult.Update(request.Name, request.Status);
            var result = await _productRepository.UpdateAsync(productResult);
            return new ApiResult<Product>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
