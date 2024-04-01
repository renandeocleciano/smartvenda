using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class DuplicataConfiguration : EntityTypeConfiguration<Duplicata>
    {
        public DuplicataConfiguration()
        {

            HasKey(c => c.DuplicataId);

            Property(c => c.NumeroNota)
            .IsRequired()
            .HasMaxLength(9);

            Property(c => c.Serie)
                .IsRequired()
                .HasMaxLength(3);

            Property(c => c.ValorPag)
                .HasPrecision(15, 2);

            Property(c => c.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.Bandeira)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.NumeroAut)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
