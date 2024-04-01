using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface IUsuarioReadOnlyRepository
    {
        Usuario GetById(Guid id);
        IEnumerable<Usuario> GetAll();
        Usuario GetByUserAndPass(string username, string pass);
    }
}
