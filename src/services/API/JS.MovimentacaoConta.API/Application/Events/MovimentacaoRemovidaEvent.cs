using JS.Core.Messages;
using JS.MovimentacaoConta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Application.Events
{
    public class MovimentacaoRemovidaEvent : Event
    {
        public Guid IdConta { get; private set; }
        public int Codigo { get; private set; }        
        public decimal Valor { get; private set; }
        public DateTime DataRegistro { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public int TipoConta { get; private set; }

        public MovimentacaoRemovidaEvent(Guid idConta,
                                            int codigo,                                            
                                            decimal valor,
                                            DateTime dataRegistro,
                                            DateTime dataPagamento,
                                            int tipo)
        {
            AggregateId = idConta;
            IdConta = idConta;
            Codigo = codigo;
            Valor = valor;
            DataRegistro = dataRegistro;
            DataPagamento = dataPagamento;
            TipoConta = tipo;
        }
    }
}
