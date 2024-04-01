using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface IPedidoReadOnlyRepository
    {
        Pedido GetByIdReadOnly(Guid id);
        IEnumerable<Pedido> GetAll();
    }
}
