using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface IProdutoVendaReadOnlyRepository
    {
        ProdutoVenda GetById(Guid id);
        IEnumerable<ProdutoVenda> GetAll();
    }
}
