using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(u => u.UsuarioId);
            
            Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Email)
                .HasMaxLength(150);

            Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(150);
            
            HasRequired(c => c.TipoUsuario)
                .WithMany(p => p.UsuarioList)
                .HasForeignKey(p => p.TipoUsuarioId);
        }
    }
}
