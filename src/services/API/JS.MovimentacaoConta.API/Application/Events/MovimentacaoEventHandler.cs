using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Application.Events
{
    public class MovimentacaoEventHandler : INotificationHandler<MovimentacaoRegistradaEvent>
    {
        public Task Handle(MovimentacaoRegistradaEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
