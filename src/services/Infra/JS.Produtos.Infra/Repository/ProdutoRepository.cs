using JS.Produtos.Infra.Data;
using JS.Core.Data;
using JS.Produtos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JS.Produtos.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProdutosContext _context;

        public ProdutoRepository(ProdutosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Produto produto)
        {
            _context.Add(produto);
        }

        public async Task<IEnumerable<Produto>> ObterPageTodos(int pageSize, int pageIndex, string query = null)
        {
            return await _context.Produtos.AsNoTracking().Where(c => c.Ativo == true).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> ObterPorName(string name)
        {
            return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(c => c.Nome.Equals(name));
        }

        public async Task<int> TotalProdutos()
        {
            return await _context.Produtos.AsNoTracking()
                 .Where(c => c.Ativo == true).CountAsync();
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Remover(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
       
    }
}