using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Services
{
    public interface ICaixaService : IServiceBase<Caixa>
    {
        Caixa GetOpened();
    }
}
