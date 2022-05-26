using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JS.MovimentacaoConta.API.Services;
using JS.Core.Utils;
using JS.MessageBus;

namespace JS.MovimentacaoConta.API.Configuration
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus(configuration.GetMessageQueueConnection("MessageBus"))
                .AddHostedService<RegistrarMovimentacaoIntegraionHandler>();
        }
    }
}