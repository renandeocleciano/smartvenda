using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface ITipoUsuarioReadOnlyRepository
    {
        TipoUsuario GetById(Guid id);
        IEnumerable<TipoUsuario> GetAll();
    }
}
