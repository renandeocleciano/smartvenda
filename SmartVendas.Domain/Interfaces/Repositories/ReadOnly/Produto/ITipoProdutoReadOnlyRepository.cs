using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Repositories
{
    public interface ITipoProdutoReadOnlyRepository
    {
        TipoProduto GetById(Guid id);
        IEnumerable<TipoProduto> GetAll();
    }
}
