using System;
using System.Collections.Generic;
using System.Text;

namespace IARATesteCotacao.Domain.Entities
{
    public class Quotation : EntityBase
    {
        protected Quotation()
        {

        }

        public Quotation(string cnpjClient, string cnpjSeller, DateTime dateStart, DateTime dateLimit, string zipCode, string address, string complementAddress, string district, string state, string comments, ICollection<ItensQuotation> itensQuotation)
        {
            CnpjClient = cnpjClient;
            CnpjSeller = cnpjSeller;
            DateStart = dateStart;
            DateLimit = dateLimit;
            ZipCode = zipCode;
            Address = address;
            ComplementAddress = complementAddress;
            District = district;
            State = state;
            Comments = comments;
            ItensQuotation = itensQuotation;
        }  
       
        public Int64 QuotationId { get; set; }
        public string CnpjClient { get; private set; }
        public string CnpjSeller { get; private set; }        
        public DateTime DateStart { get; private set; }
        public DateTime DateLimit { get; private set; }
        public string ZipCode { get; private set; }
        public string Address { get; private set; }
        public string ComplementAddress { get; private set; }
        public string District { get; private set; }
        public string State { get; private set; }
        public string Comments { get; private set; }
        public virtual ICollection<ItensQuotation> ItensQuotation { get; private set; } = new List<ItensQuotation>();

        public void Update(string cnpjClient, string cnpjSeller, DateTime dateStart, DateTime dateLimit, string zipCode, string address, string complementAddress, string district, string state, string comments, ICollection<ItensQuotation> itensQuotation)
        {
            CnpjClient = cnpjClient;
            CnpjSeller = cnpjSeller;
            DateStart = dateStart;
            DateLimit = dateLimit;
            ZipCode = zipCode;
            Address = address;
            ComplementAddress = complementAddress;
            District = district;
            State = state;
            Comments = comments;
            ItensQuotation = itensQuotation;
        }
    }
}
