using IARATesteCotacao.Business.Shared;
using MediatR;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.AddProduct
{
    public class AddProductCommand : IRequest<ApiResult>
    {        
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
