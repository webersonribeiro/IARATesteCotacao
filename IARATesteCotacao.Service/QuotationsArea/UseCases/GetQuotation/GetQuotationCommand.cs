using IARATesteCotacao.Business.Shared;
using MediatR;
using System;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.GetQuotation
{
    public class GetQuotationCommand : IRequest<ApiResult>
    {
        public Int64 Id { get; set; }
    }
}
