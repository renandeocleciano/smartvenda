using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface ITipoVendaReadOnlyRepository
    {
        TipoVenda GetById(Guid id);
        IEnumerable<TipoVenda> GetAll();
    }
}
