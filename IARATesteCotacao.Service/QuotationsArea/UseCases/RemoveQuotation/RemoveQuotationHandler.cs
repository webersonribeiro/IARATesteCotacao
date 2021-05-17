using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.RemoveQuotation
{
    public class RemoveQuotationHandler : IRequestHandler<RemoveQuotationCommand, ApiResult>
    {
        private readonly IQuotationRepository _quotationRepository;

        public RemoveQuotationHandler(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        public async Task<ApiResult> Handle(RemoveQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var quotationResult = await _quotationRepository.GetByIdAsync(request.Id);
            await _quotationRepository.DeleteAsync(quotationResult);
            return new ApiResult<Quotation>() { ResultCode = StatusCodes.Status200OK };
        }
    }
}
