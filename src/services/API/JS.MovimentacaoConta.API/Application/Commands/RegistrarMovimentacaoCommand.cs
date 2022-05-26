using System;
using FluentValidation;
using JS.Core.Messages;

namespace JS.MovimentacaoConta.API.Application.Commands
{
    public class RegistrarMovimentacaoCommand : Command
    {
        public Guid IdConta { get; private set; }
        public int Codigo { get; private set; }        
        public decimal Valor { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public int TipoConta { get; private set; }

        public RegistrarMovimentacaoCommand(Guid idConta,
                                            int codigo,
                                             
                                            decimal valor,
                                            DateTime dataRegistro,
                                            DateTime dataPagamento,
                                            int tipo)
        {
            IdConta = idConta;
            Codigo = codigo;
            Valor = valor;
            DataRegistro = dataRegistro;
            DataPagamento = dataPagamento;
            TipoConta = tipo;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarMovimentacaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RegistrarMovimentacaoValidation : AbstractValidator<RegistrarMovimentacaoCommand>
        {
            public RegistrarMovimentacaoValidation()
            {
                RuleFor(c => c.IdConta)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id inválido");

                RuleFor(c => c.Codigo)
                    .NotEmpty()
                    .WithMessage("O codigo não foi informado");

                RuleFor(c => c.DataPagamento)
                    .NotEmpty()
                    .WithMessage("Data informada não é válida.");

                RuleFor(c => c.Valor)
                    .NotEmpty()
                    .WithMessage("O valor informado não é válido.");
            }
        }
    }
}