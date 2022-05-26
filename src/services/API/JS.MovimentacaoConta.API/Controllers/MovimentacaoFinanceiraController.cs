using JS.Core.Mediator;
using JS.MovimentacaoConta.API.Services;
using JS.MovimentacaoConta.Domain.Models;
using JS.MovimentacaoConta.Infra.Data.Repository;
using JS.WebAPI.Core.Controllers;
using JS.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Controllers
{
    public class MovimentacaoFinanceiraController : MainController
    {
        private readonly MovimentacaoServices _movimentacaoServices;
        private readonly IMediatorHandler _mediator;
        public MovimentacaoFinanceiraController(MovimentacaoServices movimentacaoServices, 
                                                IMediatorHandler mediator)
        {
            _movimentacaoServices = movimentacaoServices;
            _mediator = mediator;
        }

        [HttpGet("movimentacao")]
        public async Task<PagedResult<MovimentacaoFinanceira>> ObterEndereco([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            return await _movimentacaoServices.ObterPageTodos(ps, page, q);            
        }
    }
}
