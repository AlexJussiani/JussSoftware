using FluentValidation.Results;
using JS.Core.Mediator;
using JS.Core.Messages.Integration;
using JS.MessageBus;
using JS.MovimentacaoConta.API.Application.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Services
{
    public class RegistrarMovimentacaoIntegraionHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistrarMovimentacaoIntegraionHandler(
                           IServiceProvider serviceProvider,
                           IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetSubscribers()
        {            
            _bus.SubscribeAsync<AdicionarMovimentacaoFinanceiraIntegrationEvent>("MovimentaçãoRegistrada",
                async request => await RegistrarMovimentacao(request));
            _bus.SubscribeAsync<DeletarMovimentacaoFinanciraaIntegrationEvent>("MovimentaçãoRemovida",
                async request => await RemoverMovimentacao(request));
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetSubscribers();
        }

        private async Task<ResponseMessage> RemoverMovimentacao(DeletarMovimentacaoFinanciraaIntegrationEvent message)
        {
            var movimentacaoCommand = new RemoverMovimentacaoCommand(message.IdConta);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(movimentacaoCommand);
            }
            return new ResponseMessage(sucesso);
        }

        private async Task<ResponseMessage> RegistrarMovimentacao(AdicionarMovimentacaoFinanceiraIntegrationEvent message)
        {
            
            var movimentacaoCommand = new RegistrarMovimentacaoCommand(message.IdConta, message.Codigo, message.Valor, message.DataRegistro, message.DataPagamento, message.TipoConta);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(movimentacaoCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}
