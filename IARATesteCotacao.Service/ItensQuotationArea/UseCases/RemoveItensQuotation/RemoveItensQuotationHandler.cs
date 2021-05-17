using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.RemoveItensQuotation
{
    public class RemoveItensQuotationHandler : IRequestHandler<RemoveItensQuotationCommand, ApiResult>
    {
        private readonly IItemQuotationRepository _itemQuotationRepository;

        public RemoveItensQuotationHandler(IItemQuotationRepository itemQuotationRepository)
        {
            _itemQuotationRepository = itemQuotationRepository;
        }

        public async Task<ApiResult> Handle(RemoveItensQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveItensQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var itemResult = await _itemQuotationRepository.GetByIdAsync(request.ProductId, request.QuotationId);
            await _itemQuotationRepository.DeleteAsync(itemResult);
            return new ApiResult<Product>() { ResultCode = StatusCodes.Status200OK };
        }
    }
}
