using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class NcmService : ServiceBase<Ncm>, INcmService
    {
        private readonly INcmRepository _repository;

        public NcmService(INcmRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
