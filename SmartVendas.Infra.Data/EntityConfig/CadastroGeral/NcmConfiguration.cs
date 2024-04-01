using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class NcmConfiguration : EntityTypeConfiguration<Ncm>
    {
        public NcmConfiguration()
        {
            HasKey(c => c.NcmId);

            Property(c => c.Codigo)
                .IsRequired()
                .HasMaxLength(8);

        }
    }
}
