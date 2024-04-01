using System;
using System.Collections.Generic;
using AutoMapper;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;
using SmartVendas.Domain.Interfaces.Services;
using SmartVendas.Infra.Data.Context;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Application.AppService
{
    public class ProdutoAppService : AppServiceBase<SmartVendasContext>, IProdutoAppService
    {
        private readonly IProdutoService _service;

        public ProdutoAppService(IProdutoService service)
        {
            _service = service;
        }

        public void Add(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _service.Add(produto);
            Commit();
        }

        public IEnumerable<ProdutoViewModel> BuscarPorNome(string nome)
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_service.BuscarPorNome(nome));
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_service.GetAll());
        }

        public ProdutoViewModel GetById(Guid id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_service.GetById(id));
        }

        public ProdutoViewModel GetByIdReadOnly(Guid id)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_service.GetByIdReadOnly(id));
        }

        public void Remove(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _service.Remove(produto);
            Commit();
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            var produto = Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel);
            BeginTransaction();
            _service.Update(produto);
            Commit();
        }
    }
}
