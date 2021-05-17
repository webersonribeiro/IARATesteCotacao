using IARATesteCotacao.Business.Shared;
using MediatR;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ApiResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
