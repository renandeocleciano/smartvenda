using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class LancamentoCaixaConfiguration : EntityTypeConfiguration<LancamentoCaixa>
    {
        public LancamentoCaixaConfiguration()
        {
            HasKey(l => l.LancamentoCaixaId);

            HasRequired(l => l.Caixa)
                .WithMany(c => c.Lancamentos)
                .HasForeignKey(l => l.CaixaId);
        }
    }
}
