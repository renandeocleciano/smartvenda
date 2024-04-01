using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class Ncm
    {
        public Ncm()
        {
            NcmId = Guid.NewGuid();
        }

        public Guid NcmId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Produto> ProdutoList { get; set; }
    }
}
