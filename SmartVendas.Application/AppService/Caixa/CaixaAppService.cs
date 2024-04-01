using System;
using System.Collections.Generic;
using AutoMapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Services;
using SmartVendas.Infra.Data.Context;
using SmartVendas.Application.Interfaces;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.AppService
{
    public class CaixaAppService : AppServiceBase<SmartVendasContext>, ICaixaAppService
    {
        private readonly ICaixaService _service;

        public CaixaAppService(ICaixaService service)
        {
            _service = service;
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public void Add(CaixaViewModel r)
        {
            var p = Mapper.Map<CaixaViewModel, Caixa>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public CaixaViewModel GetById(Guid id)
        {
            return Mapper.Map<Caixa, CaixaViewModel>(_service.GetById(id));
        }

        public IEnumerable<CaixaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Caixa>, IEnumerable<CaixaViewModel>>(_service.GetAll());
        }

        public void Update(CaixaViewModel r)
        {
            var p = Mapper.Map<CaixaViewModel, Caixa>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }

        public void Remove(CaixaViewModel r)
        {
            var p = Mapper.Map<CaixaViewModel, Caixa>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public CaixaViewModel GetOpened()
        {
            return Mapper.Map<Caixa, CaixaViewModel>(_service.GetOpened());
        }
    }
}
