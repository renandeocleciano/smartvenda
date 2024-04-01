using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class UnidadeMedidaConfiguration : EntityTypeConfiguration<UnidadeMedida>
    {
        public UnidadeMedidaConfiguration()
        {
            HasKey(c => c.UnidadeMedidaId);

            Property(c => c.Unidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
