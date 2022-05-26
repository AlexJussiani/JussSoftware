using JS.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.Produtos.API.Application.Events
{
    public class ProdutoRemovidoEvent : Event
    {        

        public Guid ProdutoId { get; private set; }      

        public ProdutoRemovidoEvent(Guid produtoId)
        {
            AggregateId = produtoId;
            ProdutoId = produtoId;           
        }

    }
}
