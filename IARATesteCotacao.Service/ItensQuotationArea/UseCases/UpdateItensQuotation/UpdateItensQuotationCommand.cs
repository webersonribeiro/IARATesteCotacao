using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.UpdateItensQuotation
{
    public class UpdateItensQuotationCommand : IRequest<ApiResult>
    {        
        public Int64 QuotationId { get; set; }
        public int ProductId { get; set; }        
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Unit { get; set; }
    }
}
