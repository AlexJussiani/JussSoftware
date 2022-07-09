using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JS.Clientes.Domain.Models;
using JS.Core.Data;

namespace JS.Clientes.Infra.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {        
        //Consultar

        Task<IEnumerable<Cliente>> ObterPageTodos(int pageSize, int pageIndex, string query = null);
        Task<int> TotalClientes();
        Task<Cliente> ObterPorCpf(string cpf);
        Task<Cliente> ObterPorEmail(string email);
        Task<Cliente> ObterClientePorId(Guid id);        
        Task<Endereco> ObterEnderecoPorId(Guid id);
        Task<Endereco> ObterEndereco(Guid id);

        //Adicionar
        void AdicionarEndereco(Endereco endereco);
        void AdicionarCliente(Cliente cliente);

        //Alterar
        void AtualizarCliente(Cliente cliente);
        void AtualizarEndereco(Endereco endereco);

        //Excluir

        void DeletarCliente(Cliente cliente);
    }
}