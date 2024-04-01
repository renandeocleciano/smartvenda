using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class ProdutoVendaConfiguration : EntityTypeConfiguration<ProdutoVenda>
    {
        public ProdutoVendaConfiguration()
        {
            HasKey(c => c.ProdutoVendaId);

            Property(c => c.Valor)
                .IsRequired();

            Property(c => c.Quantidade)
                .IsRequired();

        }
    }
}
