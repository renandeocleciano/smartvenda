using SmartVendas.Domain.Enumerators;
using System;

namespace SmartVendas.Domain.Entities
{
    public class LancamentoCaixa
    {
        public LancamentoCaixa()
        {
            LancamentoCaixaId = Guid.NewGuid();
        }

        public Guid LancamentoCaixaId { get; set; }
        public Guid CaixaId { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public TipoLancamentoCaixa Tipo { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual Caixa Caixa { get; set; }
    }
}