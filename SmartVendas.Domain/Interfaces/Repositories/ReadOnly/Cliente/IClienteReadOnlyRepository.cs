using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface IClienteReadOnlyRepository
    {
        Cliente GetById(Guid id);
        IEnumerable<Cliente> GetAll();
    }
}
