using FluentValidation;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.GetQuotation
{
    public class GetQuotationValidator : AbstractValidator<GetQuotationCommand>
    {
        public GetQuotationValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Informe o código da cotação para pesquisa");
        }
    }
}
