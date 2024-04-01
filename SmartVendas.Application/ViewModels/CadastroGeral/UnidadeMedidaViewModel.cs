using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Application.ViewModels
{
    public class UnidadeMedidaViewModel
    {
        public UnidadeMedidaViewModel()
        {
            UnidadeMedidaId = Guid.NewGuid();
        }
        [Key]
        public Guid UnidadeMedidaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Unidade")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Unidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutoList { get; set; }
    }
}
