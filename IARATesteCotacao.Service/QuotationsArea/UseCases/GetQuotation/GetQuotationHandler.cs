using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.GetQuotation
{
    public class GetQuotationHandler : IRequestHandler<GetQuotationCommand, ApiResult>
    {
        private readonly IQuotationRepository _quotationRepository;

        public GetQuotationHandler(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public async Task<ApiResult> Handle(GetQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var quotationResult = await _quotationRepository.GetByIdAsync(request.Id);
            return new ApiResult<Quotation>() { ResultCode = StatusCodes.Status200OK, Data = quotationResult };
        }
    }
}
