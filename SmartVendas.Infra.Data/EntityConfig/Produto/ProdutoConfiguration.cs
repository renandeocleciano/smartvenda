using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(c => c.ProdutoId);
            
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(250);

            Property(c => c.Valor)
                .IsRequired();

            //HasRequired(c => c.TipoProduto)
            //    .WithMany(p=>p.ProdutoList)
            //    .HasForeignKey(p => p.TipoProdutoId);
        }
    }
}
