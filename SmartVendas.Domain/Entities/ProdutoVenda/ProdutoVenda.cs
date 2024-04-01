using System;

namespace SmartVendas.Domain.Entities
{
    public class ProdutoVenda
    {
        public ProdutoVenda()
        {
            ProdutoVendaId = Guid.NewGuid();
        }

        public Guid ProdutoVendaId { get; set; }
        public decimal Valor { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public Guid PedidoId { get; set; }
        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual Pedido Pedido { get; set; }
        
    }
}
