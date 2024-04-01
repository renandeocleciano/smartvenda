using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class ProdutoVendaReadOnlyRepository : RepositoryBaseReadOnly, IProdutoVendaReadOnlyRepository
    {
        public IEnumerable<ProdutoVenda> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProdutoVenda GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
