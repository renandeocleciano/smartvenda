using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class TipoVendaConfiguration : EntityTypeConfiguration<TipoVenda>
    {
        public TipoVendaConfiguration()
        {
            HasKey(c => c.TipoVendaId);
            
            Property(c => c.Nome)
                .IsRequired();

        }
    }
}
