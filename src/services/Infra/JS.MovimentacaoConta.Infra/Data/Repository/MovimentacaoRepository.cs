using JS.Core.Data;
using JS.MovimentacaoConta.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JS.MovimentacaoConta.Infra.Data.Repository
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly MovimentacaoContext _context;

        public MovimentacaoRepository(MovimentacaoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AdicionarMovimentacao(MovimentacaoFinanceira movimentacao)
        {
            _context.MovimentacaoFinanceira.Add(movimentacao);
        }        

        public async Task<MovimentacaoFinanceira> ObterMovimentacaoPorId(Guid id)
        {
            return await _context.MovimentacaoFinanceira.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<MovimentacaoFinanceira>> ObterTodos(int pageSize, int pageIndex, string query = null)
        {
            return await _context.MovimentacaoFinanceira.AsNoTracking().Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
        }

        public void RemoverMovimentacao(MovimentacaoFinanceira movimentacao)
        {
            _context.MovimentacaoFinanceira.Remove(movimentacao);
        }

        public async Task<int> TotalMovimentacoes()
        {
            return await _context.MovimentacaoFinanceira.AsNoTracking()
                .CountAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
