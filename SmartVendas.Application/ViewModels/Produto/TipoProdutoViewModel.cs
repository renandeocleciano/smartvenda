using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Application.ViewModels
{
    public class TipoProdutoViewModel
    {
        public TipoProdutoViewModel()
        {
            TipoProdutoId = Guid.NewGuid();
        }
        [Key]
        public Guid TipoProdutoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Produto> ProdutoList { get; set; }
    }
}
