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
    public class UsuarioAppService : AppServiceBase<SmartVendasContext>, IUsuarioAppService
    {
        private readonly IUsuarioService _service;

        public UsuarioAppService(IUsuarioService service)
        {
            _service = service;
        }

        public void Add(UsuarioViewModel r)
        {
            var p = Mapper.Map<UsuarioViewModel, Usuario>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_service.GetAll());
        }

        public UsuarioViewModel GetById(Guid id)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_service.GetById(id));
        }

        public UsuarioViewModel GetByUserAndPass(string username, string pass)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_service.GetByUserAndPass(username, pass));
        }

        public void Remove(UsuarioViewModel r)
        {
            var p = Mapper.Map<UsuarioViewModel, Usuario>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }

        public void Update(UsuarioViewModel r)
        {
            var p = Mapper.Map<UsuarioViewModel, Usuario>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }
    }
}
