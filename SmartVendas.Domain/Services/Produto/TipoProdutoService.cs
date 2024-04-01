using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class TipoProdutoService : ServiceBase<TipoProduto>, ITipoProdutoService
    {
        private readonly ITipoProdutoRepository _repository;
        private readonly ITipoProdutoReadOnlyRepository _readOnlyRepository;

        public TipoProdutoService(ITipoProdutoRepository repository, ITipoProdutoReadOnlyRepository readOnlyRepository)
            : base(repository)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
        }

        public override IEnumerable<TipoProduto> GetAll()
        {
            return _readOnlyRepository.GetAll();
        }

        public override TipoProduto GetById(Guid id)
        {
            return _readOnlyRepository.GetById(id);
        }
    }
}
