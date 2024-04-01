using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class TipoProduto
    {
        public TipoProduto()

        {
            TipoProdutoId = Guid.NewGuid();
        }

        public Guid TipoProdutoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Produto> ProdutoList { get; set; }
    }
}
