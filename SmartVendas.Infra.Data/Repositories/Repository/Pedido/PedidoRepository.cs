using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Infra.Data.Context;
using System.Linq;

namespace SmartVendas.Infra.Data.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido, SmartVendasContext>, IPedidoRepository
    {
        public override void Update(Pedido obj)
        {
            var local = Context.Set<Pedido>().Local.FirstOrDefault(c => c.PedidoId == obj.PedidoId);

            Context.Entry(local).State = System.Data.Entity.EntityState.Detached;
            Context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
