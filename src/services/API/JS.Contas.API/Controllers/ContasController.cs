using JS.Contas.API.Application.Commands;
using JS.Contas.API.Services;
using JS.Core.Mediator;
using JS.WebAPI.Core.Controllers;
using JS.WebAPI.Core.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JS.Contas.API.Controllers
{
    [Authorize]
    public class ContasController : MainController
    {
        private readonly IAspNetUser _user;
        private readonly IMediatorHandler _mediator;

        public ContasController(IMediatorHandler mediator, IAspNetUser user)
        {
            _mediator = mediator;
            _user = user;
        }

        [HttpPost("Adicionar/Conta")]
        public async Task<IActionResult> AdicionarConta(AdicionarContaCommand conta)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _mediator.EnviarComando(conta));
        }

        [HttpPost("Adicionar/Item-Conta/{idConta:guid}")]
        public async Task<IActionResult> AdicionarItemConta(AdicionarItemContaCommand itens, Guid idConta)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _mediator.EnviarComando(itens));

        }

        [HttpPut("Atualizar-Conta/{id:guid}")]
        public async Task<IActionResult> AtualizarConta(Guid id, AtualizarContaCommand conta)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);            

            if (id != conta.Id)
            {
                AdicionarErroProcessamento("O Id informado não é o mesmo informado na Query");
                return CustomResponse();
            }

            return CustomResponse(await _mediator.EnviarComando(conta));
        }

        [HttpDelete("Remover/Item-Conta/{idConta:guid}")]
        public async Task<IActionResult> RemoverItem(Guid idConta, RemoverItemContaCommand itensProdutos)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (idConta != itensProdutos.IdConta)
            {
                AdicionarErroProcessamento("O Id informado não é o mesmo informado na Query");
                return CustomResponse();
            }

            return CustomResponse(await _mediator.EnviarComando(itensProdutos));
        }

        [HttpDelete("Remover/Conta/{idConta:guid}")]
        public async Task<IActionResult> RemoverConta(RemoverContaCommand conta)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
           

            return CustomResponse(await _mediator.EnviarComando(conta));
        }

        [HttpPut("Realizar-Pagamento")]
        public async Task<IActionResult> RealizarPagamentoConta(RealizarPagamentoCommand conta)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);           

            return CustomResponse(await _mediator.EnviarComando(conta));
        }
    }
}
