﻿using FluentValidation;

namespace IARATesteCotacao.Business.QuotationsArea.UseCases.UpdateQuotation
{
    public class UpdateQuotationValidator : AbstractValidator<UpdateQuotationCommand>
    {
        public UpdateQuotationValidator()
        {
            RuleFor(x => x.CnpjClient)
                .NotEmpty()
                .WithMessage("Campo CNPJ do Comprador é obrigatório");

            RuleFor(x => x.CnpjSeller)
                .NotEmpty()
                .WithMessage("Campo CNPJ do Fornecedor é obrigatório");

            RuleFor(x => x.DateStart)
                .NotNull()
                .WithMessage("Data de Inicio da Cotação é obrigatória");

            RuleFor(x => x.DateLimit)
                .NotNull()
                .WithMessage("Data de Entrega da Cotação é obrigatória");

            RuleFor(x => x.ZipCode)
                .NotEmpty()
                .WithMessage("Campo CEP é obrigatório");
        }
    }
}
