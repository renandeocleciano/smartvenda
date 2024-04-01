using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class TipoVendaViewModel
    {
        public TipoVendaViewModel()
        {
            TipoVendaId = Guid.NewGuid();
            VendaList = new List<VendaViewModel>();
        }

        [Key]
        public Guid TipoVendaId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<VendaViewModel> VendaList { get; set; }
    }
}
