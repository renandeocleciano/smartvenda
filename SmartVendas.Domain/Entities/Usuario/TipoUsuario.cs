using System;
using System.Collections.Generic;

namespace SmartVendas.Domain.Entities
{
    public class TipoUsuario
    {
        public TipoUsuario()
        {
            TipoUsuarioId = Guid.NewGuid();
            UsuarioList = new List<Usuario>();
        }
        public Guid TipoUsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Usuario> UsuarioList { get; set; }
    }
}
