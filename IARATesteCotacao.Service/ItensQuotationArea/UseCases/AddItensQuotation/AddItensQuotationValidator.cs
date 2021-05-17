using FluentValidation;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.AddItensQuotation
{
    public class AddItensQuotationValidator : AbstractValidator<AddItensQuotationCommand>
    {
        public AddItensQuotationValidator()
        {
            RuleFor(x => x.QuotationId)
                .NotEmpty()
                .WithMessage("Código da Cotação é obriagtório");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Produto é obrigatório");

            RuleFor(x => x.ItemNumber)
                .NotEmpty()
                .WithMessage("Número do item é obrigatório");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantidade do item é obrigatória");
        }
    }
}
