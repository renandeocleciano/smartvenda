using SmartVendas.Application.ViewModels.Enumerators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class LancamentoCaixaViewModel
    {
        public LancamentoCaixaViewModel()
        {
            LancamentoCaixaId = Guid.NewGuid();
        }

        public Guid LancamentoCaixaId { get; set; }
        public Guid CaixaId { get; set; }

        [DisplayName("Valor (R$)")]
        [Required(ErrorMessage="Informe o Valor do Lançamento")]
        public decimal Valor { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Informe a Descrição do Lançamento")]
        public string Descricao { get; set; }

        [DisplayName("Tipo do Lançamento")]
        [Required(ErrorMessage = "Informe o Tipo do Lançamento")]
        public TipoLancamentoCaixaViewModel Tipo { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual CaixaViewModel Caixa { get; set; }
    }
}
