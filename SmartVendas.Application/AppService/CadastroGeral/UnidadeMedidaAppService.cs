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
    public class UnidadeMedidaAppService : AppServiceBase<SmartVendasContext>, IUnidadeMedidaAppService
    {
        private readonly IUnidadeMedidaService _service;

        public UnidadeMedidaAppService(IUnidadeMedidaService service)
        {
            _service = service;
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public void Add(UnidadeMedidaViewModel r)
        {
            var p = Mapper.Map<UnidadeMedidaViewModel, UnidadeMedida>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public UnidadeMedidaViewModel GetById(Guid id)
        {
            return Mapper.Map<UnidadeMedida, UnidadeMedidaViewModel>(_service.GetById(id));
        }

        public IEnumerable<UnidadeMedidaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<UnidadeMedida>, IEnumerable<UnidadeMedidaViewModel>>(_service.GetAll());
        }

        public void Update(UnidadeMedidaViewModel r)
        {
            var p = Mapper.Map<UnidadeMedidaViewModel, UnidadeMedida>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }

        public void Remove(UnidadeMedidaViewModel r)
        {
            var p = Mapper.Map<UnidadeMedidaViewModel, UnidadeMedida>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }
    }
}
