﻿using JS.Produtos.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JS.Produtos.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(c => c.Descricao)
                  .IsRequired()
                  .HasColumnType("varchar(300)");
           

            builder.ToTable("Produtos");
        }
    }
}
