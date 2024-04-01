using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class Caixa
    {
        public Caixa()
        {
            CaixaId = Guid.NewGuid();
        }

        public Guid CaixaId { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime? Fechamento { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Entradas { get; set; }
        public decimal Saidas { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<LancamentoCaixa> Lancamentos { get; set; }
    }
}
