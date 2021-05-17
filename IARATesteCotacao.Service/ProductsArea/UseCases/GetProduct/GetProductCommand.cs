using IARATesteCotacao.Business.Shared;
using MediatR;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.GetProduct
{
    public class GetProductCommand : IRequest<ApiResult>
    {
        public int Id { get; set; }
    }
}
