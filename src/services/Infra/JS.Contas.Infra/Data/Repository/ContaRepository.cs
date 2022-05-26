using JS.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JS.Contas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using JS.Core.Mediator;

namespace JS.Contas.Infra.Data.Repository
{
    public class ContaRepository : IContasRepository
    {
        private readonly ContasContext _context;

        public ContaRepository(ContasContext context, IMediatorHandler mediatorHandler)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;      

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<ContaCliente>> ObterContas(TipoConta tipo, int pageSize, int pageIndex, string query = null)
        {
            return await _context.Conta.AsNoTracking().Where(c => c.TipoConta == tipo).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
        }

        public Task<IEnumerable<ContaCliente>> ObterPorCliente(TipoConta tipo, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ContaCliente> ObterPorId(Guid id)
        {
            return await _context.Conta.AsNoTracking()
                .Include(c => c.ContaItems)             
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ContaItem> ObterItemPorId(Guid id)
        {
            return await _context.ContaItens.AsNoTracking()
                .Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<ContaCliente>> ObterPorNome(TipoConta tipo, string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContaCliente>> ObterPorStatus(TipoConta tipo, int status)
        {
            throw new NotImplementedException();
        }
        public async Task<int> TotalContas(TipoConta tipo)
        {
            return await _context.Conta.AsNoTracking()
                  .Where(c => c.TipoConta == tipo).CountAsync();
        }

        public void AdicionarConta(ContaCliente conta)
        {
            _context.Conta.Add(conta);
        }

        public void AdicionarItem(ContaItem item)
        {
            _context.ContaItens.Add(item);
        }

        public void AtualizarConta(ContaCliente conta)
        {
            _context.Conta.Update(conta);
        }
        public void AtualizarItem(ContaItem item)
        {
            _context.ContaItens.Update(item);
        }

        public void RemoverItemConta(ContaItem contaItem)
        {
            _context.ContaItens.Remove(contaItem);
        }

        public void RemoverConta(ContaCliente conta)
        {
            _context.Conta.Remove(conta);
        }
    }
}