using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            ProdutoId = Guid.NewGuid();
        }

        public Guid ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public Guid UnidadeMedidaId { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }

        public Guid NcmId { get; set; }
        public virtual Ncm Ncm { get; set; }

        public Guid TipoProdutoId { get; set; }
        public virtual TipoProduto TipoProduto { get; set; }

        public virtual ICollection<ProdutoVenda> VendaList { get; set; }
    }
}
