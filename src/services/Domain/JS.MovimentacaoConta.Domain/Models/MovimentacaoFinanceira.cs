using JS.Core.DomainObjects;
using System;
namespace JS.MovimentacaoConta.Domain.Models
{
    public class MovimentacaoFinanceira : Entity, IAggregateRoot
    {
        public int Codigo { get; set; }
        public decimal Valor { get; set; }
        public int TipoConta { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataPagamento { get; set; }

        public MovimentacaoFinanceira() { }

        public MovimentacaoFinanceira(Guid id, int codigo, decimal valor, DateTime dataRegistro, DateTime dataPagamento, int tipo)
        {
            Id = id;
            Codigo = codigo;
            Valor = valor;
            DataRegistro = dataRegistro;
            DataPagamento = dataPagamento;
            TipoConta = tipo;
        }
    }
}
