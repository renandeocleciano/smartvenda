using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class LancamentoCaixaService : ServiceBase<LancamentoCaixa>, ILancamentoCaixaService
    {
        private readonly ILancamentoCaixaRepository _repository;

        public LancamentoCaixaService(ILancamentoCaixaRepository repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
