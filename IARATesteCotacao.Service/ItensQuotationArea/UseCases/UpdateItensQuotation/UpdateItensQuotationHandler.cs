using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.UpdateItensQuotation
{
    public class UpdateItensQuotationHandler : IRequestHandler<UpdateItensQuotationCommand, ApiResult>
    {
        private readonly IItemQuotationRepository _itemQuotationRepository;

        public UpdateItensQuotationHandler(IItemQuotationRepository itemQuotationRepository)
        {
            _itemQuotationRepository = itemQuotationRepository;
        }

        public async Task<ApiResult> Handle(UpdateItensQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItensQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var itemResult = await _itemQuotationRepository.GetByIdAsync(request.ProductId, request.QuotationId);
            
            itemResult.Update(
                request.Quantity, 
                request.Manufacturer, 
                request.Unit);

            var result = await _itemQuotationRepository.UpdateAsync(itemResult);
            return new ApiResult<ItensQuotation>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
