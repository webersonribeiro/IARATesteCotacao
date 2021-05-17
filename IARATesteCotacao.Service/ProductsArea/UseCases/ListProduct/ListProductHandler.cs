using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.ListProduct
{
    public class ListProductHandler : IRequestHandler<ListProductCommand, ApiResult>
    {
        private readonly IProductRepository _productRepository;

        public ListProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ApiResult> Handle(ListProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListProductValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult<IEnumerable<Product>>()
                {
                    Data = null,
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var returnlist = await _productRepository.GetAllAsync();

            return new ApiResult<IEnumerable<Product>>() { ResultCode = StatusCodes.Status200OK, Data = returnlist };
        }
    }
}
