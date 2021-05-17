using IARATesteCotacao.Business.Shared;
using MediatR;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.RemoveProduct
{
    public class RemoveProductCommand : IRequest<ApiResult>
    {
        public int Id { get; set; }
    }
}
