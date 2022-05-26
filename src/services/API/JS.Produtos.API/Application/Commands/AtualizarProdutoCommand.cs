using System;
using FluentValidation;
using JS.Core.Messages;

namespace JS.Produtos.API.Application.Commands
{
    public class AtualizarProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public decimal Valor { get; set; }

        public AtualizarProdutoCommand(Guid id, string nome, string descricao, bool ativo, decimal valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
        }
        public override bool EhValido()
        {
            ValidationResult = new AtualizarProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AtualizarProdutoValidation : AbstractValidator<AtualizarProdutoCommand>
        {
            public AtualizarProdutoValidation()
            {
                RuleFor(c => c.Id)
                    .NotEmpty()
                    .WithMessage("O Id do produto deve ser informado");
                RuleFor(c => c.Ativo)
                    .NotEmpty()
                    .WithMessage("O status do produto deve ser informado");

                RuleFor(c => c.Valor)
                    .NotEmpty()
                    .WithMessage("O valor do produto deve ser infomado");
                               
            }
        }
    }

}
