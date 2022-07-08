using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JS.Clientes.Domain.Models;
using JS.Core.Data;

namespace JS.Clientes.Infra.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);

        Task<IEnumerable<Cliente>> ObterPageTodos(int pageSize, int pageIndex, string query = null);
        Task<int> TotalClientes();
        Task<Cliente> ObterPorCpf(string cpf);
        Task<Cliente> ObterPorEmail(string email);
        Task<Cliente> ObterPorId(Guid id);
        void AdicionarEndereco(Endereco endereco);
        Task<Endereco> ObterEnderecoPorId(Guid id);
        Task<Endereco> ObterEndereco(Guid id);
        void AtualizarCliente(Cliente cliente);
        void DeletarCliente(Cliente cliente);
        void AtualizarEndereco(Endereco endereco);
    }
}