using System;

namespace SmartVendas.Domain.Entities
{
    public class Duplicata
    {
        public Duplicata()
        {
            DuplicataId = Guid.NewGuid();
        }

        public Guid DuplicataId { get; set; }
        public string NumeroNota { get; set; }
        public string Serie { get; set; }
        public decimal ValorPag { get; set; }
        public string Cnpj { get; set; }
        public string Bandeira { get; set; }
        public string NumeroAut { get; set; }
    }
}
