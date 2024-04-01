using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
        }
        [Key]
        public Guid ClienteId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(11, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cpf { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<PedidoViewModel> PedidoList { get; set; }
    }
}
