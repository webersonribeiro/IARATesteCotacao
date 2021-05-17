using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.GetItensQuotation
{
    public class GetItensQuotationCommand : IRequest<ApiResult>
    {
        public Int64 QuotationId { get; set; }
        public int ProductId { get; set; }

    }
}
