using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Infra.Data.Context;

namespace SmartVendas.Infra.Data.Repositories.Repository
{
    public class ProdutoVendaRepository : RepositoryBase<ProdutoVenda, SmartVendasContext>, IProdutoVendaRepository
    {
    }
}
