using System;

namespace SmartVendas.Domain.Entities
{
    public class DadosItens
    {
        public DadosItens()
        {
            DadosItensId = Guid.NewGuid();
        }

        public Guid DadosItensId { get; set; }
        public string NumeroNota { get; set; }
        public string Serie { get; set; }
        public string NumeroItem { get; set; }
        public string ProdCProd { get; set; }
        public string Descricao { get; set; }
        public string ProdCEAN { get; set; }
        public string ProdNCM { get; set; }
        public string ProdEXTIPI { get; set; }
        public string ProdCFOP { get; set; }
        public string ProdUCom { get; set; }
        public decimal ProdQCom { get; set; }
        public decimal ProdVUnCom { get; set; }
        public string ProdUTrib { get; set; }
        public decimal ProdQTrib { get; set; }
        public decimal ProdVUnTrib { get; set; }
        public string ProdCEANTrib { get; set; }
        public decimal ProdVFrete { get; set; }
        public decimal ProdVSeg { get; set; }
        public decimal ProdVDesc { get; set; }
        public decimal ProdVProd { get; set; }
        public decimal ProdVTotalTributo { get; set; }
        public decimal ProdVOutro { get; set; }
        public string ProdIndTot { get; set; }
        public string ProdXPed { get; set; }
        public string ProdNPed { get; set; }

        //Dados de ICMS

        public string ICMSCST { get; set; }
        public string ICMSOrig { get; set; }
        public string ICMSModBC { get; set; }
        public decimal ICMSPRedBC { get; set; }
        public decimal ICMSVBC { get; set; }
        public decimal ICMSPICMS { get; set; }
        public decimal ICMSVICMS { get; set; }
        public decimal ICMSDesonerado { get; set; }
        public string ICMSMotDes { get; set; }

        //Dados PIS e COFINS

        public string PISCST { get; set; }
        public string COFINSCST { get; set; }
    }
}
