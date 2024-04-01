using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Infra.Data.Context;

namespace SmartVendas.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto, SmartVendasContext>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return base.Find(c => c.Nome == nome);
        }
    }
}
