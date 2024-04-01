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
    public class ProdutoVendaAppService : AppServiceBase<SmartVendasContext>, IProdutoVendaAppService
    {
        private readonly IProdutoVendaService _service;

        public ProdutoVendaAppService(IProdutoVendaService service)
        {
            _service = service;
        }

        public void Add(ProdutoVendaViewModel p)
        {
            var produto = Mapper.Map<ProdutoVendaViewModel, ProdutoVenda>(p);
            BeginTransaction();
            _service.Add(produto);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<ProdutoVendaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ProdutoVenda>, IEnumerable<ProdutoVendaViewModel>>(_service.GetAll());
        }

        public ProdutoVendaViewModel GetById(Guid id)
        {
            return Mapper.Map<ProdutoVenda, ProdutoVendaViewModel>(_service.GetById(id));
        }

        public void Remove(ProdutoVendaViewModel p)
        {
            var produto = Mapper.Map<ProdutoVendaViewModel, ProdutoVenda>(p);
            BeginTransaction();
            _service.Remove(produto);
            Commit();
        }

        public void Update(ProdutoVendaViewModel p)
        {
            var produto = Mapper.Map<ProdutoVendaViewModel, ProdutoVenda>(p);
            BeginTransaction();
            _service.Update(produto);
            Commit();
        }
    }
}
