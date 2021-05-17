using FluentValidation;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.ListItensQuotation
{
    public class ListItensQuotationValidator : AbstractValidator<ListItensQuotationCommand>
    {
        public ListItensQuotationValidator()
        {
            RuleFor(x => x.QuotationId)
                .NotEmpty()
                .WithMessage("Informe o código da cotação para pesquisa");
        }
    }
}
