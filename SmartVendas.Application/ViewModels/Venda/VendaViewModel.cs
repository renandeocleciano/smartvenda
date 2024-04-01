using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class VendaViewModel
    {
        public VendaViewModel()
        {
            VendaId = Guid.NewGuid();
        }

        [Key]
        public Guid VendaId { get; set; }

        public int Desconto { get; set; }
        
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        [DisplayName("Tipo Venda")]
        public Guid TipoVendaId { get; set; }
        public virtual TipoVendaViewModel TipoVenda { get; set; }
        public Guid PedidoId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
