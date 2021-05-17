using System;
using System.Collections.Generic;
using System.Text;

namespace IARATesteCotacao.Domain.Entities
{
    public class ItensQuotation : EntityBase
    {
        protected ItensQuotation()
        {

        }

        public ItensQuotation(int itemNumber, Int64 quotationId, int productId, decimal price, int quantity, string manufacturer, string unit)
        {
            ItemNumber = itemNumber;
            QuotationId = quotationId;
            ProductId = productId;
            Price = price;
            Quantity = quantity;
            Manufacturer = manufacturer;
            Unit = unit;
        }

        public int ItemNumber { get; protected set; }
        public Int64 QuotationId { get; protected set; }
        public virtual Quotation Quotation { get; protected set; }
        public int ProductId { get; protected set; }
        public virtual Product Product { get; protected set; }
        public  decimal Price { get; protected set; }
        public int Quantity { get; protected set; }
        public string Manufacturer { get; protected set; }
        public string  Unit { get; protected set; }
        
        public void Update(int quantity, string manufacturer, string unit)
        {            
            Quantity = quantity;
            Manufacturer = manufacturer;
            Unit = unit;
        }
    }
}
