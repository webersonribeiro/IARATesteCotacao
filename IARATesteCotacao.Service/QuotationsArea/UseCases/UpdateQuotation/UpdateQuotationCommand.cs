using IARATesteCotacao.Business.QuotationsArea.UseCases.AddQuotation;
using IARATesteCotacao.Business.Shared;
using IARATesteCotacao.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.UpdateQuotation
{
    public class UpdateQuotationCommand : IRequest<ApiResult>
    {
        public Int64 Id { get; set; }
        public string CnpjClient { get; set; }
        public string CnpjSeller { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateLimit { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string ComplementAddress { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Comments { get; set; }
        public ICollection<ItemQuotationCommand> ItensQuotation { get; set; } = new List<ItemQuotationCommand>();

    }
}
