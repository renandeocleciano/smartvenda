using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class NcmViewModel
    {
        public NcmViewModel()
        {
            NcmId = Guid.NewGuid();
        }
        [Key]
        public Guid NcmId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Codigo")]
        [MaxLength(8, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(8, ErrorMessage = "Mínimo {0} caracteres")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<ProdutoViewModel> ProdutoList { get; set; }
    }
}
