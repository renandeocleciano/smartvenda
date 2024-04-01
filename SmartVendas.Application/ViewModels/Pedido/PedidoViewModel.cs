using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SmartVendas.Application.ViewModels
{
    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            PedidoId = Guid.NewGuid();
            Status = StatusPedidoViewModel.Aguardando;
        }
        [Key]
        public Guid PedidoId { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DhInicio { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DhProducao { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DhFinalizado { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public bool Pago { get; set; }

        [DisplayName("Status do Pedido")]
        public StatusPedidoViewModel Status { get; set; }
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }
        public virtual ClienteViewModel Cliente { get; set; }
        public virtual ICollection<ProdutoVendaViewModel> ProdutoVendaList { get; set; }
    }
}
