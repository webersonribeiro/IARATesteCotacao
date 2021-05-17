using FluentValidation;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.RemoveProduct
{
    public class RemoveProductValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Informe o código do produto para exclusão");
        }
    }
}
