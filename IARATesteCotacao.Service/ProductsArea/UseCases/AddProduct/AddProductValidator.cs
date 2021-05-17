using FluentValidation;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Informe o nome do produto");
            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("Ibforme o status do produto");

        }
    }
}
