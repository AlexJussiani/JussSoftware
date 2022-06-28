﻿// <auto-generated />
using System;
using JS.MovimentacaoConta.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JS.MovimentacaoConta.Infra.Migrations
{
    [DbContext(typeof(MovimentacaoContext))]
    [Migration("20220125225622_MovimentacaoFinanceira")]
    partial class MovimentacaoFinanceira
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JS.MovimentacaoConta.Domain.Models.MovimentacaoFinanceira", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MovimentacaoFinanceira");
                });
#pragma warning restore 612, 618
        }
    }
}