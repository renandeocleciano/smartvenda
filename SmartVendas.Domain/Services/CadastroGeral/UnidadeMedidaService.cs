using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class UnidadeMedidaService : ServiceBase<UnidadeMedida>, IUnidadeMedidaService
    {
        private readonly IUnidadeMedidaRepository _repository;

        public UnidadeMedidaService(IUnidadeMedidaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
