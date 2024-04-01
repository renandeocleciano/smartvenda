using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class VendaService : ServiceBase<Venda>, IVendaService
    {
        private readonly IVendaRepository _repository;
        private readonly IVendaReadOnlyRepository _readOnlyRepository;

        public VendaService(IVendaRepository repository, IVendaReadOnlyRepository readOnlyRepository)
            :base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        //public override IEnumerable<Venda> GetAll()
        //{
        //    return _readOnlyRepository.GetAll();
        //}

        //public override Venda GetById(Guid id)
        //{
        //    return _readOnlyRepository.GetById(id);
        //}
    }
}
