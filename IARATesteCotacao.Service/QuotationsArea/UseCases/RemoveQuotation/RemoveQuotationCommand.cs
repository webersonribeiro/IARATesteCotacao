using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.RemoveQuotation
{
    public class RemoveQuotationCommand : IRequest<ApiResult>
    {
        public Int64 Id { get; set; }
    }
}
