using System.ComponentModel.DataAnnotations.Schema;
using SmartVendas.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class ClienteConfigutarion : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfigutarion()
        {
            HasKey(c => c.ClienteId);
            
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.SobreNome)
                .HasMaxLength(100);

            Property(c => c.Cpf)
                .HasMaxLength(14);
        }
    }
}
