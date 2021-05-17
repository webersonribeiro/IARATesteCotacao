using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.ListItensQuotation
{
    public class ListItensQuotationHandler : IRequestHandler<ListItensQuotationCommand, ApiResult>
    {
        private readonly IItemQuotationRepository _itemQuotationRepository;

        public ListItensQuotationHandler(IItemQuotationRepository itemQuotationRepository)
        {
            _itemQuotationRepository = itemQuotationRepository;
        }

        public async Task<ApiResult> Handle(ListItensQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListItensQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult<IEnumerable<ItensQuotation>>()
                {
                    Data = null,
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var returnlist = await _itemQuotationRepository.GetAllAsync(request.QuotationId);
            return new ApiResult<IEnumerable<ItensQuotation>>() { ResultCode = StatusCodes.Status200OK, Data = returnlist };
        }
    }
}
