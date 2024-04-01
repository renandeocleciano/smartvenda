using System;
using System.Collections.Generic;
using AutoMapper;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Services;
using SmartVendas.Infra.Data.Context;

namespace SmartVendas.Application.AppService
{
    public class TipoProdutoAppService : AppServiceBase<SmartVendasContext>, ITipoProdutoAppService
    {
        private readonly ITipoProdutoService _service;

        public TipoProdutoAppService(ITipoProdutoService service)
        {
            _service = service;
        }

        public void Add(TipoProdutoViewModel t)
        {
            var p = Mapper.Map<TipoProdutoViewModel, TipoProduto>(t);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }
        
        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TipoProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TipoProduto>, IEnumerable<TipoProdutoViewModel>>(_service.GetAll());
        }

        public TipoProdutoViewModel GetById(Guid id)
        {
            return Mapper.Map<TipoProduto, TipoProdutoViewModel>(_service.GetById(id));
        }

        public void Remove(TipoProdutoViewModel t)
        {
            var p = Mapper.Map<TipoProdutoViewModel, TipoProduto>(t);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(TipoProdutoViewModel t)
        {
            var p = Mapper.Map<TipoProdutoViewModel, TipoProduto>(t);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
