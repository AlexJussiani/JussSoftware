using FluentValidation.Results;
using JS.Core.Mediator;
using JS.Core.Messages;
using JS.Produtos.API.Application.Events;
using JS.Produtos.Domain.Models;
using JS.Produtos.Infra.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JS.Produtos.API.Application.Commands
{
    public class ProdutoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarProdutoCommand, ValidationResult>,
        IRequestHandler<AtualizarProdutoCommand, ValidationResult>,
        IRequestHandler<DeletarProdutoCommand, ValidationResult>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository, IMediatorHandler mediatorHandler)
        {
            _produtoRepository = produtoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> Handle(RegistrarProdutoCommand message, CancellationToken cancellationToken)
        {
            var produto = new Produto(message.Nome, message.Descricao, message.Ativo, message.Valor);
            if (!message.EhValido()) return message.ValidationResult;

            var produtoExistente = await _produtoRepository.ObterPorName(message.Nome);
            if(produtoExistente != null)
            {
                AdicionarErro("Esse produto já foi cadastrado.");
                return ValidationResult;
            }

            _produtoRepository.Adicionar(produto);

            produto.AdicionarEvento(new ProdutoRegistradoEvent(produto.Id, produto.Nome, produto.Descricao, produto.Ativo, produto.Valor));
            return await PersistirDados(_produtoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(AtualizarProdutoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var produto = await _produtoRepository.ObterPorId(message.Id);

            if(produto == null)
            {
                AdicionarErro("Esse produto não foi localizado. ");
                return ValidationResult;
            }
            //Mapear Produto
            produto.setNome(message.Nome);
            produto.setDescricao(message.Descricao);
            produto.setAtivo(message.Ativo);
            produto.setValor(message.Valor);

            _produtoRepository.Atualizar(produto);

            produto.AdicionarEvento(new ProdutoAtualizadoEvent(produto.Id, produto.Nome, produto.Descricao, produto.Ativo, produto.Valor));

            return await PersistirDados(_produtoRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeletarProdutoCommand message, CancellationToken cancellationToken)
        {
            if(!message.EhValido()) return message.ValidationResult;

            var produto = await _produtoRepository.ObterPorId(message.Id);

            if(produto == null)
            {
                AdicionarErro("Produto não foi localizado. ");
                return ValidationResult;
            }

            //produto.AdicionarEvento(new ProdutoRemovidoEvent(message.Id));
            await _mediatorHandler.PublicarEvento(new ProdutoRemovidoEvent(message.Id));
            _produtoRepository.Remover(produto);
            

            return await PersistirDados(_produtoRepository.UnitOfWork);
        }
    }
}
