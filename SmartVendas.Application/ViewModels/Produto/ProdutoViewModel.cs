using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            ProdutoId = Guid.NewGuid();
        }

        [Key]
        [DisplayName("Id")]
        public Guid ProdutoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        [DisplayName("Disponivel?")]
        public bool Disponivel { get; set; }
        [DisplayName("Unidade de Medida")]
        public Guid UnidadeMedidaId { get; set; }
        public virtual UnidadeMedidaViewModel UnidadeMedida { get; set; }

        [DisplayName("Ncm")]
        public Guid NcmId { get; set; }
        public virtual NcmViewModel Ncm { get; set; }

        [DisplayName("Tipo Produto")]
        public Guid TipoProdutoId { get; set; }
        public virtual TipoProdutoViewModel TipoProduto { get; set; }
        public virtual ICollection<ProdutoVendaViewModel> ProdutoVendaList { get; set; }
    }
}
