using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class CaixaViewModel
    {
        public CaixaViewModel()
        {
            CaixaId = Guid.NewGuid();
        }

        public Guid CaixaId { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime? Fechamento { get; set; }
        [DisplayName("Saldo Inicial *")]
        [Required(ErrorMessage ="Informe o Saldo Inicial")]
        public decimal SaldoInicial { get; set; }
        public decimal Entradas { get; set; }
        public decimal Saidas { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public decimal Total {
            get
            {
                return (SaldoInicial + Entradas) - Saidas;
            }
        }
        

        public virtual ICollection<LancamentoCaixaViewModel> Lancamentos { get; set; }
    }
}
