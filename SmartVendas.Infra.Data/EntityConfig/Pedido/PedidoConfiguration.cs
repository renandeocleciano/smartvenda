using System.ComponentModel.DataAnnotations.Schema;
using SmartVendas.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(c => c.PedidoId);

            HasRequired(c => c.Cliente)
               .WithMany(p => p.PedidoList)
               .HasForeignKey(p => p.ClienteId);
            
        }
    }
}
