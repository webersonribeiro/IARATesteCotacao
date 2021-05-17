using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.GetItensQuotation
{
    public class GetItensQuotationHandler : IRequestHandler<GetItensQuotationCommand, ApiResult>
    {
        private readonly IItemQuotationRepository _itemQuotationRepository;

        public GetItensQuotationHandler(IItemQuotationRepository itemQuotationRepository)
        {
            _itemQuotationRepository = itemQuotationRepository;
        }

        public async Task<ApiResult> Handle(GetItensQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetItensQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var itemQuotation = await _itemQuotationRepository.GetByIdAsync(request.ProductId, request.QuotationId);
            return new ApiResult<ItensQuotation>() { ResultCode = StatusCodes.Status200OK, Data = itemQuotation };            
        }
    }
}
