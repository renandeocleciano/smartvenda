using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class ProdutoVendaService : ServiceBase<ProdutoVenda>, IProdutoVendaService
    {
        private readonly IProdutoVendaRepository _repository;
        private readonly IProdutoVendaReadOnlyRepository _readOnlyRepository;

        public ProdutoVendaService(IProdutoVendaRepository repository, IProdutoVendaReadOnlyRepository readOnlyRepository)
            :base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        public override IEnumerable<ProdutoVenda> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public override ProdutoVenda GetById(Guid id)
        {
            return _readOnlyRepository.GetById(id);
        }
    }
}
