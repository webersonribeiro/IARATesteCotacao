using IARATesteCotacao.Business.Services.Locality;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.UpdateQuotation
{
    public class UpdateQuotationHandler : IRequestHandler<UpdateQuotationCommand, ApiResult>
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly ILocalityService _localityService;

        public UpdateQuotationHandler(IQuotationRepository quotationRepository, ILocalityService localityService)
        {
            _quotationRepository = quotationRepository;
            _localityService = localityService;
        }

        public async Task<ApiResult> Handle(UpdateQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var quotationResult = await _quotationRepository.GetByIdAsync(request.Id);

            var itens = new List<ItensQuotation>();

            var localityViaCep = await _localityService.GetByCep(request.ZipCode);

            if (request.Address == string.Empty || request.District == string.Empty || request.State == string.Empty)
            {
                request.Address = localityViaCep.logradouro;
                request.District = localityViaCep.bairro;
                request.State = localityViaCep.uf;
            }

            foreach (var item in request.ItensQuotation)
            {
                itens.Add(new ItensQuotation(item.ItemNumber, item.QuotationId, item.ProductId, item.Price, item.Quantity, item.Manufacturer, item.Unit));
            }

            quotationResult.Update(request.CnpjClient,
                request.CnpjSeller,
                request.DateStart,
                request.DateLimit,
                request.ZipCode,
                request.Address,
                request.ComplementAddress,
                request.District,
                request.State,
                request.Comments,
                itens);
                                                
            var result = await _quotationRepository.UpdateAsync(quotationResult);
            return new ApiResult<Quotation>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
