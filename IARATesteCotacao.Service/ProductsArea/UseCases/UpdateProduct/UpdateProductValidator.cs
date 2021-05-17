using FluentValidation;

namespace IARATesteCotacao.Business.ProductsArea.UseCases.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
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
