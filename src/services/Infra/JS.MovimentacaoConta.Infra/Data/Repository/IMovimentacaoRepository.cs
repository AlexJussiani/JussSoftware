using JS.Core.Data;
using JS.MovimentacaoConta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.Infra.Data.Repository
{
    public interface IMovimentacaoRepository : IRepository<MovimentacaoFinanceira>
    {
        Task<MovimentacaoFinanceira> ObterMovimentacaoPorId(Guid id);
        void AdicionarMovimentacao(MovimentacaoFinanceira movimentacao);
        void RemoverMovimentacao(MovimentacaoFinanceira movimentacao);
        Task<IEnumerable<MovimentacaoFinanceira>> ObterTodos(int pageSize, int pageIndex, string query = null);
        Task<int> TotalMovimentacoes();
    }
}
