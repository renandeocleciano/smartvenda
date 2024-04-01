using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class TipoUsuarioConfiguration : EntityTypeConfiguration<TipoUsuario>
    {
        public TipoUsuarioConfiguration()
        {
            HasKey(u => u.TipoUsuarioId);
            
            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

        }
    }
}
