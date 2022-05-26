using System;
using FluentValidation;
using JS.Core.Messages;

namespace JS.MovimentacaoConta.API.Application.Commands
{
    public class RemoverMovimentacaoCommand : Command
    {
        public Guid IdConta { get; private set; }
        

        public RemoverMovimentacaoCommand(Guid idConta)
        {
            IdConta = idConta;
           
        }

        public override bool EhValido()
        {
            ValidationResult = new RemoverMovimentacaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RemoverMovimentacaoValidation : AbstractValidator<RemoverMovimentacaoCommand>
        {
            public RemoverMovimentacaoValidation()
            {
                RuleFor(c => c.IdConta)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id inválido");               
            }
        }
    }
}