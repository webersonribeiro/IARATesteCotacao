using System;
using System.Collections.Generic;
using System.Text;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.AddQuotation
{
    public class ItemQuotationCommand
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
