using System.Data.Entity.ModelConfiguration;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Infra.Data.EntityConfig
{
    public class DadosNotaConfiguration : EntityTypeConfiguration<DadosNota>
    {
        public DadosNotaConfiguration()
        {
            HasKey(c => c.DadosNotaId);

            Property(c => c.NumeroNota)
            .IsRequired()
            .HasMaxLength(9);

            Property(c => c.Serie)
            .IsRequired()
            .HasMaxLength(3);

            Property(c => c.Modelo)
            .IsRequired()
            .HasMaxLength(2);

            Property(c => c.DataEmissao)
            .IsRequired()
            .HasMaxLength(10);

            Property(c => c.DataSaida)
            .IsRequired()
            .HasMaxLength(10);

            Property(c => c.NaturezaOperacao)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.TipoNota)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.FormaPagamento)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.CodMunicipioGerador)
            .IsRequired()
            .HasMaxLength(7);

            Property(c => c.TipoEmissao)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.FinalidadeNota)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.TipoImpressao)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.ModFrete)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.IndOperacao)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.ConsumidorFinal)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.CompPresente)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.CSCtoken)
            .IsRequired()
            .HasMaxLength(60);


            Property(c => c.EmitTipoDoc)
            .IsRequired()
            .HasMaxLength(4);

            Property(c => c.EmitCNPJ_CPF)
            .IsRequired()
            .HasMaxLength(14);

            Property(c => c.EmitXNome)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitXFant)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitIE)
            .IsRequired()
            .HasMaxLength(14);

            Property(c => c.EmitIEST)
            .IsRequired()
            .HasMaxLength(14);

            Property(c => c.EmitIM)
            .IsRequired()
            .HasMaxLength(15);

            Property(c => c.EmitCNAE)
            .IsRequired()
            .HasMaxLength(7);

            Property(c => c.EmitCRT)
            .IsRequired()
            .HasMaxLength(1);

            Property(c => c.EmitEnderEmitXLgr)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitEnderEmitNro)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitEnderEmitXCpl)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitEnderEmitXBairro)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitEnderEmitCEP)
            .IsRequired()
            .HasMaxLength(8);

            Property(c => c.EmitEnderEmitXPais)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitEnderEmitUF)
            .IsRequired()
            .HasMaxLength(2);

            Property(c => c.EmitEnderEmitXMun)
            .IsRequired()
            .HasMaxLength(60);

            Property(c => c.EmitEnderEmitFone)
            .IsRequired()
            .HasMaxLength(14);

            Property(c => c.EmitEnderEmitCMun)
                .IsRequired()
                .HasMaxLength(7);

            Property(c => c.EmitEnderEmitCPais)
                .IsRequired()
                .HasMaxLength(4);

            Property(c => c.DestTipoDoc)
                .IsRequired()
                .HasMaxLength(4);

            Property(c => c.DestCNPJ_CPF)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.DestXNome)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestIE)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.IndIE)
                .IsRequired()
                .HasMaxLength(1);

            Property(c => c.DestISUF)
                .IsRequired()
                .HasMaxLength(9);

            Property(c => c.DestEmail)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestXLgr)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestNro)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestXCpl)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestXBairro)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestCEP)
                .IsRequired()
                .HasMaxLength(8);

            Property(c => c.DestEnderDestXPais)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestUF)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.DestEnderDestXMun)
                .IsRequired()
                .HasMaxLength(60);

            Property(c => c.DestEnderDestFone)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.DestEnderDestCMun)
                .IsRequired()
                .HasMaxLength(7);

            Property(c => c.DestEnderDestCPais)
                .IsRequired()
                .HasMaxLength(4);


            Property(c => c.TotalVBC)
               .HasPrecision(15, 2);
            Property(c => c.TotalVICMS)
                .HasPrecision(15, 2);
            Property(c => c.TotalVBCST)
                .HasPrecision(15, 2);
            Property(c => c.TotalVST)
                .HasPrecision(15, 2);
            Property(c => c.TotalVProd)
                .HasPrecision(15, 2);
            Property(c => c.TotalVFrete)
                .HasPrecision(15, 2);
            Property(c => c.TotalVSeg)
                .HasPrecision(15, 2);
            Property(c => c.TotalVDesc)
                .HasPrecision(15, 2);
            Property(c => c.TotalVIPI)
                .HasPrecision(15, 2);
            Property(c => c.TotalVPIS)
                .HasPrecision(15, 2);
            Property(c => c.TotalVCOFINS)
                .HasPrecision(15, 2);
            Property(c => c.TotalVOutro)
                .HasPrecision(15, 2);
            Property(c => c.TotalVDesoneracao)
                .HasPrecision(15, 2);
            Property(c => c.TotalVNF)
                .HasPrecision(15, 2);
            Property(c => c.TotalTributos)
                .HasPrecision(15, 2);

            Property(c => c.InfAdicInfAdFisco)
                .IsRequired()
                .HasColumnType("Text");

            Property(c => c.InfAdicInfCpl)
                .IsRequired()
                 .HasColumnType("Text");


        }
    }
}
