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
    public class PedidoAppService : AppServiceBase<SmartVendasContext>, IPedidoAppService
    {
        private readonly IPedidoService _service;
        public PedidoAppService(IPedidoService service)
        {
            _service = service;
        }

        public void Add(PedidoViewModel r)
        {
            var p = Mapper.Map<PedidoViewModel, Pedido>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<PedidoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_service.GetAll());
        }

        public PedidoViewModel GetById(Guid id)
        {
            return Mapper.Map<Pedido, PedidoViewModel>(_service.GetById(id));
        }

        public void Remove(PedidoViewModel r)
        {
            var p = Mapper.Map<PedidoViewModel, Pedido>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(PedidoViewModel r)
        {
            var p = Mapper.Map<PedidoViewModel, Pedido>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
