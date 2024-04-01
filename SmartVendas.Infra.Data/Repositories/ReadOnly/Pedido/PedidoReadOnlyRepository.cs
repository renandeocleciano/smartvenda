using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class PedidoReadOnlyRepository : RepositoryBaseReadOnly, IPedidoReadOnlyRepository
    {
        public IEnumerable<Pedido> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pedido GetByIdReadOnly(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
