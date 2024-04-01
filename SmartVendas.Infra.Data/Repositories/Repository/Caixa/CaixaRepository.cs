using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Infra.Data.Context;
using System.Linq;

namespace SmartVendas.Infra.Data.Repositories
{
    public class CaixaRepository : RepositoryBase<Caixa, SmartVendasContext>, ICaixaRepository
    {
        public override void Update(Caixa obj)
        {
            var local = Context.Set<Caixa>().Local.FirstOrDefault(c => c.CaixaId == obj.CaixaId);

            Context.Entry(local).State = System.Data.Entity.EntityState.Detached;
            Context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
