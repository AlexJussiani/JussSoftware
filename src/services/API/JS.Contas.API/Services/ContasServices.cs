using FluentValidation.Results;
using JS.Contas.Domain.Models;
using JS.Contas.Infra.Data.Repository;
using JS.Core.Messages;
using JS.Core.Messages.Integration;
using JS.MessageBus;
using JS.WebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JS.Contas.API.Services
{   
    public class ContasServices : CommandHandler
    {
        private readonly IContasRepository _contaRepository;
        private readonly IMessageBus _bus;

        public ContasServices(IContasRepository contaRepository, IMessageBus bus)
        {
            _contaRepository = contaRepository;
            _bus = bus;
        }

        public async Task<ValidationResult> CadastrarConta(ContaCliente conta)
        {
            conta.CalcularValorConta();
            _contaRepository.AdicionarConta(conta);

            return await PersistirDados(_contaRepository.UnitOfWork);            
        }

        //public async Task<PagedResult<ContaCliente>> ObterContas(TipoContaDTO tipo, int pageSize, int pageIndex, string query = null)
        //{
        //    var contasPagar = await _contaRepository.ObterContas(tipo, pageSize, pageIndex, query);

        //    return new PagedResult<ContaCliente>()
        //    {
        //        List = contasPagar,
        //        TotalResults = await _contaRepository.TotalContas(tipo),
        //        PageIndex = pageIndex,
        //        PageSize = pageSize,
        //        Query = query
        //    };
        //}

        //public async Task<ResponseMessage> RegistrarPagamentoRecebimento(Guid idConta)
        //{
        //    var conta = await _contaRepository.ObterPorId(idConta);
        //    conta.StatusConta = StatusConta.Pago;
        //    var movimentacaoRegistrada = new MovimentacaoFinanceiraIntegrationEvent(
        //        Guid.NewGuid(), conta.Codigo, conta.Id, conta.ValorTotal, DateTime.Now, conta.DataVencimento, ((int)conta.TipoConta));
        //    try
        //    {
        //        //Comunicação com a API Movimentações através do RabbitMQ
        //        _contaRepository.UpdateConta(conta);
        //        await PersistirDados(_contaRepository.UnitOfWork);
        //        return await _bus.RequestAsync<MovimentacaoFinanceiraIntegrationEvent, ResponseMessage>(movimentacaoRegistrada);

        //    }
        //    catch
        //    {
        //        conta.StatusConta = StatusConta.Pendente;
        //        _contaRepository.UpdateConta(conta);
        //        await PersistirDados(_contaRepository.UnitOfWork);
        //        throw;
        //    }
        //}

        public async Task<ResponseMessage> DeletarConta(Guid idConta)
        {
            var conta = await _contaRepository.ObterPorId(idConta);
            if(conta.StatusConta == StatusConta.Pago)
            {
                //comunicar com a API Movimentações através do RabbitMQ
            }
            return null;
        }
    }
}
