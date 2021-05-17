using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.ListQuotation
{
    public class ListQuotationHandler : IRequestHandler<ListQuotationCommand, ApiResult>
    {
        private readonly IQuotationRepository _quotationRepository;
                public ListQuotationHandler(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public async Task<ApiResult> Handle(ListQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListQuotationValidator();

            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult<IEnumerable<Quotation>>()
                {
                    Data = null,
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var returnlist = await _quotationRepository.GetAllAsync();

            return new ApiResult<IEnumerable<Quotation>>() { ResultCode = StatusCodes.Status200OK, Data = returnlist };
        }
    }
}
