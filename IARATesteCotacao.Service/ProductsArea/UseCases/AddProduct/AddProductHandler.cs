using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.AddProduct
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ApiResult>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResult> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var newProduct = new Product(request.Name, request.Status);
            var result = await _productRepository.AddAsync(newProduct);
            return new ApiResult<Product>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
