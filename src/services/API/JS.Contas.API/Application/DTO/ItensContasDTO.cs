using JS.Contas.Domain.Models;
using System;

namespace JS.Contas.API.Application.DTO
{
    public class ItensContasDTO
    {
        public ItensContasDTO(Guid idItem, Guid contaId, Guid produtoId, string nome, int quantidade, decimal valor)
        {
            IdItem = idItem;
            ContaId = contaId;
            ProdutoId = produtoId;
            Nome = nome;
            Valor = valor;
            Quantidade = quantidade;
        }

        public Guid IdItem { get; set; }
        public Guid ContaId { get; private set; }
        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        public static ContaItem ParaContaItem(ItensContasDTO itensContasDTO)
        {
            return new ContaItem(itensContasDTO.ContaId, itensContasDTO.ProdutoId, itensContasDTO.Nome, itensContasDTO.Quantidade,
                itensContasDTO.Valor);
        }

        public static ItensContasDTO ParaContaItemDTO(ContaItem itensContas)
        {
            return new ItensContasDTO(itensContas.Id, itensContas.ContaId, itensContas.ProdutoId, itensContas.ProdutoNome, itensContas.Quantidade,
                itensContas.ValorUnitario);
        }
    }
}
