using FluentValidation;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.GetProduct
{
    public class GetProductValidator : AbstractValidator<GetProductCommand>
    {
        public GetProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Informe o código do produto para pesquisa");
        }
    }
}
