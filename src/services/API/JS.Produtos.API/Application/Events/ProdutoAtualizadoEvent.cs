using JS.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Produtos.API.Application.Events
{
    public class ProdutoAtualizadoEvent : Event
    {
        public Guid ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }

        public ProdutoAtualizadoEvent(Guid produtoId,
                                      string nome,
                                      string descricao,
                                      bool ativo,
                                      decimal valor)
        {
            AggregateId = produtoId;
            ProdutoId = produtoId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
        }
    }
}
