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
    public class VendaAppService : AppServiceBase<SmartVendasContext>, IVendaAppService
    {
        private readonly IVendaService _service;

        public VendaAppService(IVendaService service)
        {
            _service = service;
        }

        public void Add(VendaViewModel r)
        {
            var p = Mapper.Map<VendaViewModel, Venda>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<VendaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Venda>, IEnumerable<VendaViewModel>>(_service.GetAll());
        }

        public VendaViewModel GetById(Guid id)
        {
            return Mapper.Map<Venda, VendaViewModel>(_service.GetById(id));
        }

        public void Remove(VendaViewModel r)
        {
            var p = Mapper.Map<VendaViewModel, Venda>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(VendaViewModel r)
        {
            var p = Mapper.Map<VendaViewModel, Venda>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
