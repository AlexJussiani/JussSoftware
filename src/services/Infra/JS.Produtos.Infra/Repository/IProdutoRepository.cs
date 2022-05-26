using JS.Produtos.Domain.Models;
using JS.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JS.Produtos.Infra.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        void Adicionar(Produto produto);

        Task<IEnumerable<Produto>> ObterPageTodos(int pageSize, int pageIndex, string query = null);
        Task<int> TotalProdutos();
        Task<Produto> ObterPorName(string name);
        Task<Produto> ObterPorId(Guid id);
        void Atualizar(Produto produto);
        void Remover(Produto produto);

    }
}