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
    public class TipoVendaAppService : AppServiceBase<SmartVendasContext>, ITipoVendaAppService
    {
        private readonly ITipoVendaService _service;

        public TipoVendaAppService(ITipoVendaService service)
        {
            _service = service;
        }

        public void Add(TipoVendaViewModel r)
        {
            var p = Mapper.Map<TipoVendaViewModel, TipoVenda>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TipoVendaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TipoVenda>, IEnumerable<TipoVendaViewModel>>(_service.GetAll());
        }

        public TipoVendaViewModel GetById(Guid id)
        {
            return Mapper.Map<TipoVenda, TipoVendaViewModel>(_service.GetById(id));
        }

        public void Remove(TipoVendaViewModel r)
        {
            var p = Mapper.Map<TipoVendaViewModel, TipoVenda>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(TipoVendaViewModel r)
        {
            var p = Mapper.Map<TipoVendaViewModel, TipoVenda>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
