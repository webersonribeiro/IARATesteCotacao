using FluentValidation;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.RemoveQuotation
{
    public class RemoveQuotationValidator : AbstractValidator<RemoveQuotationCommand>
    {
        public RemoveQuotationValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Informe o código da cotação para exclusão");
        }
    }
}
