using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmartVendas.Application.ViewModels
{
    public class ProdutoVendaViewModel
    {
        public ProdutoVendaViewModel()
        {
            ProdutoVendaId = Guid.NewGuid();
        }
        [Key]
        public Guid ProdutoVendaId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }
        public decimal Quantidade { get; set; }
        public Guid PedidoId { get; set; }
        [DisplayName("Produto")]
        public Guid ProdutoId { get; set; }
        public virtual ProdutoViewModel Produto { get; set; }
        public virtual PedidoViewModel Pedido { get; set; }

    }
}
