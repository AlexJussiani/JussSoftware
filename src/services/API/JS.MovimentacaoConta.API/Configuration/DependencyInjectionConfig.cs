using Microsoft.Extensions.DependencyInjection;
using JS.Core.Mediator;
using JS.MovimentacaoConta.Infra.Data;
using JS.MovimentacaoConta.Infra.Data.Repository;
using MediatR;
using JS.MovimentacaoConta.API.Application.Events;
using JS.MovimentacaoConta.API.Application.Commands;
using FluentValidation.Results;
using JS.MovimentacaoConta.API.Services;
using JS.EventSourcing;
using JS.Core.Data.EventSourcing;

namespace JS.Movimentacao.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            
            //Command
            services.AddScoped<IRequestHandler<RegistrarMovimentacaoCommand, ValidationResult>, MovimentacaoCommandHandler>();

            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Event Sourcing
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();

            //services.AddScoped<INotificationHandler<MovimentacaoRegistradaEvent>, MovimentacaoEventHandler>();

            services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
            services.AddScoped<MovimentacaoServices>();
            services.AddScoped<MovimentacaoContext>();
        }
    }
}