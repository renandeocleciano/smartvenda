using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class TipoProdutoConfiguration : EntityTypeConfiguration<TipoProduto>
    {
        public TipoProdutoConfiguration()
        {
            HasKey(c => c.TipoProdutoId);
            
            Property(c => c.Nome)
                .IsRequired();
            
        }
    }
}
