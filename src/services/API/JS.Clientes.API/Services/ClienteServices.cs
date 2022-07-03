using FluentValidation.Results;
using JS.Clientes.Domain.Models;
using JS.Clientes.Infra.Repository;
using JS.Core.Messages;
using JS.WebAPI.Core.Models;
using System;
using System.Threading.Tasks;

namespace JS.Clientes.API.Services
{   
    public class ClienteServices : CommandHandler
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> AtualizarCliente(Guid id, Cliente cliente)
        {
           
            var cpf = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);
            var email = await _clienteRepository.ObterPorEmail(cliente.Email.Endereco);
            if(email != null && email.Id != id)
            {
                AdicionarErro("Este email já está em uso.");
                return ValidationResult;
            }
            if (cpf != null && cpf.Id != id)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }
            var c = await _clienteRepository.ObterPorId(id);
            cliente.Id = c.Id;
            _clienteRepository.AtualizarCliente(cliente);
            return await PersistirDados(_clienteRepository.UnitOfWork);
        }

        public async Task<ValidationResult> CadastrarCliente(Cliente cliente)
        {
            if (!string.IsNullOrEmpty(cliente.Cpf.Numero))
            {
                var cpf = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);
                if (cpf != null)
                {
                    AdicionarErro("Este CPF já está em uso.");
                    return ValidationResult;
                }
            }

            if (!string.IsNullOrEmpty(cliente.Email.Endereco))
            {
                var email = await _clienteRepository.ObterPorEmail(cliente.Email.Endereco);
                if (email != null)
                {
                    AdicionarErro("Este Email já está em uso.");
                    return ValidationResult;
                }
            }
            _clienteRepository.Adicionar(cliente);

            return await PersistirDados(_clienteRepository.UnitOfWork);            
        }

        public async Task<PagedResult<Cliente>> ObterClientes(int pageSize, int pageIndex, string query = null)
        {
            var clientes = await _clienteRepository.ObterPageTodos(pageSize,pageIndex,query);  
            
            return new PagedResult<Cliente>()
            {
                List = clientes,
                TotalResults = await _clienteRepository.TotalClientes(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }

        public async Task<ValidationResult> DeletarCliente(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);
            _clienteRepository.DeletarCliente(cliente);
            return await PersistirDados(_clienteRepository.UnitOfWork);
        }

        public async Task<Cliente> ObterPorIdService(Guid id)
        {
            return await _clienteRepository.ObterPorId(id);            
        }

        public async Task<Cliente> ObterPorCpfService(string cpf)
        {
            return await _clienteRepository.ObterPorCpf(cpf);
        }
    }
}
