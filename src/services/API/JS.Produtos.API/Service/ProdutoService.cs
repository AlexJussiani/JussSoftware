using FluentValidation.Results;
using JS.Core.Messages;
using JS.Produtos.Domain.Models;
using JS.Produtos.Infra.Repository;
using JS.WebAPI.Core.Models;
using System.Threading.Tasks;

namespace JS.Produtos.API.Service
{
    public class ProdutoService : CommandHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<PagedResult<Produto>> ObterProdutos(int pageSize, int pageIndex, string query = null)
        {
            var clientes = await _produtoRepository.ObterPageTodos(pageSize, pageIndex, query);

            return new PagedResult<Produto>()
            {
                List = clientes,
                TotalResults = await _produtoRepository.TotalProdutos(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }
    }
}
