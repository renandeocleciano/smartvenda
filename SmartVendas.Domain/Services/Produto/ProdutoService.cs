using System;
using System.Collections.Generic;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;

namespace SmartVendas.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoReadOnlyRepository _produtoReadOnlyRepository;

        public ProdutoService(IProdutoRepository produtoRepository, IProdutoReadOnlyRepository produtoReadOnlyRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoReadOnlyRepository = produtoReadOnlyRepository;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }

        public override IEnumerable<Produto> GetAll()
        {
            return _produtoReadOnlyRepository.GetAll();
        }
        
        public Produto GetByIdReadOnly(Guid id)
        {
            return _produtoReadOnlyRepository.GetByIdReadOnly(id);
        }
    }
}
