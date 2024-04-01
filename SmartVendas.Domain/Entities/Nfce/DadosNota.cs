
using System;

namespace SmartVendas.Domain.Entities
{
    public class DadosNota
    {
        public DadosNota()
        {
            DadosNotaId = Guid.NewGuid();
        }

        public Guid DadosNotaId { get; set; }

        //Dados Gerais da Nota

        public string NumeroNota { get; set; }
        public string Serie { get; set; }
        public string Modelo { get; set; }
        public string DataEmissao { get; set; }
        public string DataSaida { get; set; }
        public string NaturezaOperacao { get; set; }
        public string TipoNota { get; set; }
        public string FormaPagamento { get; set; }
        public string CodMunicipioGerador { get; set; }
        public string TipoEmissao { get; set; }
        public string FinalidadeNota { get; set; }
        public string TipoImpressao { get; set; }
        public string ModFrete { get; set; }
        public string IndOperacao { get; set; }
        public string ConsumidorFinal { get; set; }
        public string CompPresente { get; set; }
        public string CSCtoken { get; set; }


        //Dados Gerais do Emitente

        public string EmitTipoDoc { get; set; }
        public string EmitCNPJ_CPF { get; set; }
        public string EmitXNome { get; set; }
        public string EmitXFant { get; set; }
        public string EmitIE { get; set; }
        public string EmitIEST { get; set; }
        public  string EmitIM { get; set; }
        public string EmitCNAE { get; set; }
        public string EmitCRT { get; set; }
        public string EmitEnderEmitXLgr { get; set; }
        public string EmitEnderEmitNro { get; set; }
        public string EmitEnderEmitXCpl { get; set; }
        public string EmitEnderEmitXBairro { get; set; }
        public string EmitEnderEmitCEP { get; set; }
        public string EmitEnderEmitXPais { get; set; }
        public string EmitEnderEmitUF { get; set; }
        public string EmitEnderEmitXMun { get; set; }
        public string EmitEnderEmitFone { get; set; }
        public string EmitEnderEmitCMun { get; set; }
        public string EmitEnderEmitCPais { get; set; }


        //Dados Gerais do Destinatário

        public string DestTipoDoc { get; set; }
        public string DestCNPJ_CPF { get; set; }
        public string DestXNome { get; set; }
        public string DestIE { get; set; }
        public string IndIE { get; set; }
        public string DestISUF { get; set; }
        public string DestEmail { get; set; }
        public string DestEnderDestXLgr { get; set; }
        public string DestEnderDestNro { get; set; }
        public string DestEnderDestXCpl { get; set; }
        public string DestEnderDestXBairro { get; set; }
        public string DestEnderDestCEP { get; set; }
        public string DestEnderDestXPais { get; set; }
        public string DestEnderDestUF { get; set; }
        public string DestEnderDestXMun { get; set; }
        public string DestEnderDestFone { get; set; }
        public string DestEnderDestCMun { get; set; }
        public string DestEnderDestCPais { get; set; }


        //Totais da Nota

        public decimal TotalVBC { get; set; }
        public decimal TotalVICMS { get; set; }
        public decimal TotalVBCST { get; set; }
        public decimal TotalVST { get; set; }
        public decimal TotalVProd { get; set; }
        public decimal TotalVFrete { get; set; }
        public decimal TotalVSeg { get; set; }
        public decimal TotalVDesc { get; set; }
        public decimal TotalVIPI { get; set; }
        public decimal TotalVPIS { get; set; }
        public decimal TotalVCOFINS { get; set; }
        public decimal TotalVOutro { get; set; }
        public decimal TotalVDesoneracao { get; set; }
        public decimal TotalVNF { get; set; }
        public decimal TotalTributos { get; set; }

        //Observação
        public string InfAdicInfAdFisco { get; set; }
        public string InfAdicInfCpl { get; set; }
    }
}
