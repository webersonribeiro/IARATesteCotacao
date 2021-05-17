using IARATesteCotacao.Business.Services.Locality;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using IARATesteCotacao.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.AddQuotation
{
    public class AddQuotationHandler : IRequestHandler<AddQuotationCommand, ApiResult>
    {
        private readonly IQuotationRepository _quotationRepository;
        private readonly ILocalityService _localityService;

        public AddQuotationHandler(IQuotationRepository quotationRepository, ILocalityService localityService)
        {
            _quotationRepository = quotationRepository;
            _localityService = localityService;
        }

        public async Task<ApiResult> Handle(AddQuotationCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddQuotationValidator();
            var validationresults = await validator.ValidateAsync(request);

            if (!validationresults.IsValid)
                return new ApiResult()
                {
                    Errors = validationresults.Errors,
                    ResultCode = StatusCodes.Status400BadRequest
                };

            var localityViaCep = await _localityService.GetByCep(request.ZipCode);

            if (request.Address == string.Empty || request.District == string.Empty || request.State == string.Empty)
            {
                request.Address = localityViaCep.logradouro;
                request.District = localityViaCep.bairro;
                request.State = localityViaCep.uf;
            }

            var itens = new List<ItensQuotation>();

            int iNumber = 1;
            // Ordenação dos itens ?
            foreach (var item in request.ItensQuotation)
            {
                itens.Add(new ItensQuotation(iNumber, item.QuotationId, item.ProductId, item.Price, item.Quantity, item.Manufacturer, item.Unit));
                iNumber++;
            }

            var newCotation = new Quotation(request.CnpjClient,
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

            var result = await _quotationRepository.AddAsync(newCotation);            
            return new ApiResult<Quotation>() { ResultCode = StatusCodes.Status200OK, Data = result };
        }
    }
}
