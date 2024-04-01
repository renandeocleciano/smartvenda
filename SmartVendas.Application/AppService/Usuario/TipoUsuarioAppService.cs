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
    public class TipoUsuarioAppService : AppServiceBase<SmartVendasContext>, ITipoUsuarioAppService
    {
        private readonly ITipoUsuarioService _service;

        public TipoUsuarioAppService(ITipoUsuarioService service)
        {
            _service = service;
        }

        public void Add(TipoUsuarioViewModel r)
        {
            var p = Mapper.Map<TipoUsuarioViewModel, TipoUsuario>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<TipoUsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TipoUsuario>, IEnumerable<TipoUsuarioViewModel>>(_service.GetAll());
        }

        public TipoUsuarioViewModel GetById(Guid id)
        {
            return Mapper.Map<TipoUsuario, TipoUsuarioViewModel>(_service.GetById(id));
        }

        public void Remove(TipoUsuarioViewModel r)
        {
            var p = Mapper.Map<TipoUsuarioViewModel, TipoUsuario>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(TipoUsuarioViewModel r)
        {
            var p = Mapper.Map<TipoUsuarioViewModel, TipoUsuario>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
