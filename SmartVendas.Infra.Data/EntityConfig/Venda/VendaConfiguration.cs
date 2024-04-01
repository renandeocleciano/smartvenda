using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class VendaConfiguration : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguration()
        {
            HasKey(c => c.VendaId);

            //HasRequired(c => c.TipoVenda)
            //    .WithMany(p => p.VendaList)
            //    .HasForeignKey(p => p.TipoVendaId);
            
            //HasMany(v => v.ProdutoList)
            //    .WithMany(p => p.VendaList)
            //    .Map(me =>
            //    {
            //        me.MapLeftKey("VendaId");
            //        me.MapRightKey("ProdutoId");
            //        me.ToTable("VendaProdutos");
            //    });
        }
    }
}
