using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.AddItensQuotation
{
    public class AddItensQuotationCommand : IRequest<ApiResult>
    {
        public int ItemNumber { get; set; }
        public Int64 QuotationId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string Unit { get; set; }
    }
}
