using JS.Core.DomainObjects;
using System;

namespace JS.Produtos.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Produto() { }

        public Produto(string nome, string descricao, bool ativo, decimal valor)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
        }

        public bool EstaDisponivel(int quantidade)
        {
            return Ativo;
        }

        public void setNome(string nome)
        {
            Nome = nome;
        }
        public void setDescricao(string descricao)
        {
            Descricao = descricao;
        }
        public void setAtivo(bool ativo)
        {
            Ativo = ativo;
        }
        public void setValor(decimal valor)
        {
            Valor = valor;
        }
    }
}
