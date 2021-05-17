using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.AddItensQuotation
{
    public class AddItensQuotationHandler : IRequestHandler<AddItensQuotationCommand, ApiResult>
    {
        private readonly IItemQuotationRepository _itemQuotationRepository;
        public AddItensQuotationHandler(IItemQuotationRepository itemQuotationRepository)
        {
            _itemQuotationRepository = itemQuotationRepository;
        }

        public async Task<ApiResult> Handle(AddItensQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddItensQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var newItemQuotation = new ItensQuotation(
                request.ItemNumber,
                request.QuotationId,
                request.ProductId,
                request.Price,
                request.Quantity,
                request.Manufacturer,
                request.Unit);

            var result = await _itemQuotationRepository.AddAsync(newItemQuotation);
            return new ApiResult<ItensQuotation>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
