using SmartVendas.Infra.Data.Interfaces;

namespace SmartVendas.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}
