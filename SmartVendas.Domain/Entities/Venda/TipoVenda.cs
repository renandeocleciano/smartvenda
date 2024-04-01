using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class TipoVenda
    {
        public TipoVenda()
        {
            TipoVendaId = Guid.NewGuid();
            VendaList = new List<Venda>();    
        }

        public Guid TipoVendaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Venda> VendaList { get; set; }
    }
}
