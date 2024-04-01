using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class Pedido
    {
        public Pedido()
        {
            PedidoId = Guid.NewGuid();
            ProdutoVendaList = new List<ProdutoVenda>();
            Status = StatusPedido.Aguardando;
        }

        public Guid PedidoId { get; set; }
        public DateTime DhInicio { get; set; }
        public DateTime DhProducao { get; set; }
        public DateTime DhFinalizado { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Pago { get; set; }
        public StatusPedido Status { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<ProdutoVenda> ProdutoVendaList { get; set; }
    }
}
