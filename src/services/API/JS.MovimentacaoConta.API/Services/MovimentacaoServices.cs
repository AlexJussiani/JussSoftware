using JS.Core.Messages;
using JS.MovimentacaoConta.Domain.Models;
using JS.MovimentacaoConta.Infra.Data.Repository;
using JS.WebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.API.Services
{
    public class MovimentacaoServices : CommandHandler
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoServices(IMovimentacaoRepository movimentacaoRepository)
        {
            _movimentacaoRepository = movimentacaoRepository;
        }


        public async Task<PagedResult<MovimentacaoFinanceira>> ObterPageTodos(int pageSize, int pageIndex, string query = null)
        {
            var clientes = await _movimentacaoRepository.ObterTodos(pageSize, pageIndex, query);

            return new PagedResult<MovimentacaoFinanceira>()
            {
                List = clientes,
                TotalResults = await _movimentacaoRepository.TotalMovimentacoes(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }
    }
}
