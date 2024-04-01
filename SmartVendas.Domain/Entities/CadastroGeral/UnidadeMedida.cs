using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class UnidadeMedida
    {
        public UnidadeMedida()
        {
            UnidadeMedidaId = Guid.NewGuid();
        }

        public Guid UnidadeMedidaId { get; set; }
        public string Unidade { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Produto> ProdutoList { get; set; }
    }
}
