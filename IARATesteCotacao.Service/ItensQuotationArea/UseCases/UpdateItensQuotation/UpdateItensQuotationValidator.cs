using FluentValidation;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.UpdateItensQuotation
{
    public class UpdateItensQuotationValidator : AbstractValidator<UpdateItensQuotationCommand>
    {
        public UpdateItensQuotationValidator()
        {
            RuleFor(x => x.QuotationId)
                .NotEmpty()
                .WithMessage("Código da Cotação é obriagtório");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Produto é obrigatório");           

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantidade do item é obrigatória");
        }
    }
}
