using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface IVendaReadOnlyRepository
    {
        Venda GetById(Guid id);
        IEnumerable<Venda> GetAll();
    }
}
