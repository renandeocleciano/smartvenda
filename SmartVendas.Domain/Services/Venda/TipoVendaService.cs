using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class TipoVendaService : ServiceBase<TipoVenda>, ITipoVendaService
    {
        private readonly ITipoVendaRepository _repository;
        private readonly ITipoVendaReadOnlyRepository _readOnlyRepository;

        public TipoVendaService(ITipoVendaRepository repository, ITipoVendaReadOnlyRepository readOnlyRepository)
            :base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        public override IEnumerable<TipoVenda> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public override TipoVenda GetById(Guid id)
        {
            return _readOnlyRepository.GetById(id);
        }
    }
}
