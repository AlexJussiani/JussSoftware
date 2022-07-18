﻿using JS.Clientes.API.Services;
using JS.Clientes.Domain.Models;
using JS.WebAPI.Core.Controllers;
using JS.WebAPI.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JS.WebAPI.Core.Identidade;
using System;
using System.Threading.Tasks;

namespace JS.Clientes.API.Controllers
{
    [Authorize]
    [Route("api/clientes")]
    public class ClientesController : MainController
    {
        private readonly ClienteServices _clienteServices;        

        public ClientesController(ClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet()]
        public async Task<PagedResult<Cliente>> Index([FromQuery] int ps = 8, [FromQuery] int page = 1, [FromQuery] string q = null)
        {
            return await _clienteServices.ObterClientes(ps, page, q);
        }

        [HttpGet("{Id:guid}")]
        public async Task<Cliente> ClienteDetalhe(Guid id)
        {
             return await _clienteServices.ObterPorIdService(id);
        }


        [HttpGet("endereco/{Id:guid}")]
        public async Task<Endereco> ObterEnderecoPorId(Guid id)
        {
            return await _clienteServices.ObterEnderecoPorId(id);
        }

        [HttpGet("cpf")]
        public async Task<Cliente> ObterCpf(string cpf)
        {
            return await _clienteServices.ObterPorCpfService(cpf);

        }
        [ClaimsAuthorize("Cliente", "Cadastrar")]
        [HttpPost()]
        public async Task<ActionResult> Registrar(Cliente cliente)

        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteServices.CadastrarCliente(cliente));           
        }
        [ClaimsAuthorize("Cliente", "Cadastrar")]
        [HttpPost("endereco")]
        public async Task<ActionResult> AdicionarEndereco(Endereco endereco)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteServices.AdicionarEndereco(endereco));
        }
        [ClaimsAuthorize("Cliente", "Atualizar")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> AtualizarCliente(Guid id, Cliente cliente)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteServices.AtualizarCliente(id, cliente));
        }
        [ClaimsAuthorize("Cliente", "Atualizar")]
        [HttpPut("endereco/{id:guid}")]
        public async Task<ActionResult> AtualizarEndereco(Guid id, Endereco endereco)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteServices.AtualizarEndereco(id, endereco));
        }
        [ClaimsAuthorize("Cliente", "Remover")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeletarCliente(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(await _clienteServices.DeletarCliente(id));
        }
    }
}
