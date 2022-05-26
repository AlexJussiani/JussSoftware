using FluentValidation;
using JS.Core.Messages;
using System;

namespace JS.Contas.API.Application.Commands
{
    public class AtualizarContaCommand : Command
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataVencimento { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarContaValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarContaValidation : AbstractValidator<AtualizarContaCommand>
        {
            public AtualizarContaValidation()
            {
                RuleFor(c => c.ClienteId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do cliente inválido");

                RuleFor(c => c.DataVencimento)
                    .NotNull()
                    .WithMessage("Data de vencimento deve ser informada");
            }
        }
    }
}
