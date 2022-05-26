using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JS.Produtos.API.Application.Events
{
    public class ProdutoEventHandler : INotificationHandler<ProdutoRegistradoEvent>
    {
        public Task Handle(ProdutoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
