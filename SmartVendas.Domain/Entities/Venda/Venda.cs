using System;

namespace SmartVendas.Domain.Entities
{
    public class Venda
    {
        public Venda()
        {
            VendaId = Guid.NewGuid();
        }

        public Guid VendaId { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public int Desconto { get; set; }

        public Guid PedidoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoVendaId { get; set; }
        public virtual TipoVenda TipoVenda { get; set; }
        
    }
}
