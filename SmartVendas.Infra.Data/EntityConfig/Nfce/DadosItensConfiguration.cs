using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class DadosItensConfiguration : EntityTypeConfiguration<DadosItens>
    {
        public DadosItensConfiguration()
        {
            HasKey(c => c.DadosItensId);

            Property(c => c.NumeroNota)
                .IsRequired()
                .HasMaxLength(9);

            Property(c => c.Serie)
                .IsRequired()
                .HasMaxLength(3);

            Property(c => c.NumeroItem)
                .IsRequired()
                .HasMaxLength(3);

            Property(c => c.ProdCProd)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(120);

            Property(c => c.ProdCEAN)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.ProdNCM)
                .IsRequired()
                .HasMaxLength(8);

            Property(c => c.ProdEXTIPI)
                .IsRequired()
                .HasMaxLength(3);

            Property(c => c.ProdCFOP)
                .IsRequired()
                .HasMaxLength(4);

            Property(c => c.ProdUCom)
                .IsRequired()
                .HasMaxLength(6);

            Property(c => c.ProdQTrib)
                .HasPrecision(12, 4);

            Property(c => c.ProdVUnTrib)
                .HasPrecision(21, 10);

            Property(c => c.ProdCEANTrib)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.ProdVFrete)
                .HasPrecision(15, 2);

            Property(c => c.ProdVSeg)
                .HasPrecision(15, 2);

            Property(c => c.ProdVDesc)
                .HasPrecision(15, 2);

            Property(c => c.ProdVProd)
                .HasPrecision(15, 2);

            Property(c => c.ProdVTotalTributo)
                .HasPrecision(15, 2);

            Property(c => c.ProdVOutro)
                .HasPrecision(15, 2);
            
            Property(c => c.ProdIndTot)
                .IsRequired()
                .HasMaxLength(1);

            Property(c => c.ProdXPed)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.ProdNPed)
                .IsRequired()
                .HasMaxLength(6);

            Property(c => c.ICMSCST)
                .IsRequired()
                .HasMaxLength(3);

            Property(c => c.ICMSOrig)
                .IsRequired()
                .HasMaxLength(1);

            Property(c => c.ICMSModBC)
                .IsRequired()
                .HasMaxLength(1);

            Property(c => c.ICMSPRedBC)
                .HasPrecision(5,2);

            Property(c => c.ICMSVBC)
                .HasPrecision(15, 2);

            Property(c => c.ICMSPICMS)
                .HasPrecision(5, 2);

            Property(c => c.ICMSVICMS)
                .HasPrecision(15, 2);

            Property(c => c.ICMSDesonerado)
                .HasPrecision(13, 2);

            Property(c => c.ICMSMotDes)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.PISCST)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.COFINSCST)
                .IsRequired()
                .HasMaxLength(2);

        }
    }
}
