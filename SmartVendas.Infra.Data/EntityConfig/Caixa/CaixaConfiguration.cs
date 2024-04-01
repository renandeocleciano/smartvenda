using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class CaixaConfiguration : EntityTypeConfiguration<Caixa>
    {
        public CaixaConfiguration()
        {
            HasKey(c => c.CaixaId);
        }
    }
}
