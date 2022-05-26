using FluentValidation.Results;
using JS.Core.Mediator;
using JS.Produtos.API.Service;
using JS.Produtos.API.Application.Commands;
using JS.Produtos.Infra.Data;
using JS.Produtos.Infra.Repository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using JS.EventSourcing;
using JS.Core.Data.EventSourcing;

namespace JS.Produtos.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Command
            services.AddScoped<IRequestHandler<RegistrarProdutoCommand, ValidationResult>, ProdutoCommandHandler>();

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Event Sourcing
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();

            //Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ProdutosContext>();
            services.AddScoped<ProdutoService>();
           
        }
    }    
}