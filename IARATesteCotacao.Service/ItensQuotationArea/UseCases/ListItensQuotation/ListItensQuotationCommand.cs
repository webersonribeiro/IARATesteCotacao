using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.ListItensQuotation
{
    public class ListItensQuotationCommand : IRequest<ApiResult>
    {
        public Int64 QuotationId { get; set; }
    }
}
