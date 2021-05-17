using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.RemoveItensQuotation
{
    public class RemoveItensQuotationCommand : IRequest<ApiResult>
    {
        public Int64 QuotationId { get; set; }
        public int ProductId { get; set; }
    }
}
