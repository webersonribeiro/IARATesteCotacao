using FluentValidation;

namespace IARATesteCotacao.Business.ItensQuotationArea.UseCases.RemoveItensQuotation
{
    public class RemoveItensQuotationValidator : AbstractValidator<RemoveItensQuotationCommand>
    {
        public RemoveItensQuotationValidator()
        {
            RuleFor(x => x.QuotationId)
                .NotEmpty()
                .WithMessage("Informe código de cotação para exclusão de produto");
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Informe código do produto a ser excluído");

        }
    }
}
