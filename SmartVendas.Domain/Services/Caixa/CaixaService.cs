using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;
using System.Linq;

namespace SmartVendas.Domain.Services
{
    public class CaixaService : ServiceBase<Caixa>, ICaixaService
    {
        private readonly ICaixaRepository _repository;

        public CaixaService(ICaixaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Caixa GetOpened()
        {
            return _repository.Find(c => c.Fechamento == null).FirstOrDefault();
        }
    }
}
