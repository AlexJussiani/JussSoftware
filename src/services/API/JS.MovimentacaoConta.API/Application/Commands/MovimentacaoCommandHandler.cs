using FluentValidation.Results;
using JS.Core.Messages;
using JS.MovimentacaoConta.API.Application.Events;
using JS.MovimentacaoConta.Domain.Models;
using JS.MovimentacaoConta.Infra.Data.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Application.Commands
{
    public class MovimentacaoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarMovimentacaoCommand, ValidationResult>,
        IRequestHandler<RemoverMovimentacaoCommand, ValidationResult>
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoCommandHandler(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarMovimentacaoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var movimentacao = new MovimentacaoFinanceira(message.IdConta,
                                                            message.Codigo,                                                            
                                                            message.Valor,
                                                            message.DataRegistro,
                                                            message.DataPagamento,
                                                            message.TipoConta
                                                            );

           _movimentacaoRepository.AdicionarMovimentacao(movimentacao);

            movimentacao.AdicionarEvento(new MovimentacaoRegistradaEvent(message.IdConta,
                                                            message.Codigo,
                                                            message.Valor,
                                                            message.DataRegistro,
                                                            message.DataPagamento,
                                                            message.TipoConta));

            return await PersistirDados(_movimentacaoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverMovimentacaoCommand message, CancellationToken cancellationToken)
        {
            var movimentacao = await _movimentacaoRepository.ObterMovimentacaoPorId(message.IdConta);

            if(movimentacao == null)
            {
                AdicionarErro("Conta não localizada! ");
                return new ValidationResult();
            }

            movimentacao.AdicionarEvento(new MovimentacaoRemovidaEvent(message.IdConta,
                                                            movimentacao.Codigo,
                                                            movimentacao.Valor,
                                                            movimentacao.DataRegistro,
                                                            movimentacao.DataPagamento,
                                                            movimentacao.TipoConta));

            _movimentacaoRepository.RemoverMovimentacao(movimentacao);

            return await PersistirDados(_movimentacaoRepository.UnitOfWork);
        }
    }
}
