using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class TipoUsuarioViewModel
    {
        public TipoUsuarioViewModel()
        {
            TipoUsuarioId = Guid.NewGuid();
            UsuarioList = new List<UsuarioViewModel>();
        }

        [Key]
        public Guid TipoUsuarioId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<UsuarioViewModel> UsuarioList { get; set; }
    }
}
