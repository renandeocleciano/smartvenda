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
    public class ClienteAppService : AppServiceBase<SmartVendasContext>, IClienteAppService
    {
        private readonly IClienteService _service;
        public ClienteAppService(IClienteService service)
        {
            _service = service;
        }

        public void Add(ClienteViewModel r)
        {
            var p = Mapper.Map<ClienteViewModel, Cliente>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_service.GetAll());
        }

        public ClienteViewModel GetById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_service.GetById(id));
        }

        public void Remove(ClienteViewModel r)
        {
            var p = Mapper.Map<ClienteViewModel, Cliente>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(ClienteViewModel r)
        {
            var p = Mapper.Map<ClienteViewModel, Cliente>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
