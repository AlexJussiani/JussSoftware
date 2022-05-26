using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JS.MovimentacaoConta.Domain.Models;

namespace JS.MovimentacaoConta.Infra.Data.Mappings
{
    public class MovimentacaoContaMappings : IEntityTypeConfiguration<MovimentacaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoFinanceira> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("MovimentacaoFinanceira");
        }
    }
}
