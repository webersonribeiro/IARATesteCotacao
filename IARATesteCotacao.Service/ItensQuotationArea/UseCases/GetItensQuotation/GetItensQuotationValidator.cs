using FluentValidation;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.GetItensQuotation
{
    public class GetItensQuotationValidator : AbstractValidator<GetItensQuotationCommand>
    {
        public GetItensQuotationValidator()
        {
            RuleFor(x => x.QuotationId)
                .NotEmpty()
                .WithMessage("Informe código de cotação para pequisa");
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Informe código do produto para pesquisa");
        }
    }
}
