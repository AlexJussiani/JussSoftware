using System;
using FluentValidation;
using JS.Core.Messages;

namespace JS.Produtos.API.Application.Commands
{
    public class DeletarProdutoCommand : Command
    {
        public Guid Id { get; set; }       

        public DeletarProdutoCommand(Guid id)
        {
            Id = id;
        }
        public override bool EhValido()
        {
            ValidationResult = new DeletarProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DeletarProdutoValidation : AbstractValidator<DeletarProdutoCommand>
        {
            public DeletarProdutoValidation()
            {                

                RuleFor(c => c.Id)
                    .NotEmpty()
                    .WithMessage("O id do produto deve ser informado");               
                               
            }
        }
    }

}
