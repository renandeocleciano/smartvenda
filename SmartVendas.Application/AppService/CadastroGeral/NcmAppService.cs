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
    public class NcmAppService : AppServiceBase<SmartVendasContext>, INcmAppService
    {
        private readonly INcmService _service;

        public NcmAppService(INcmService service)
        {
            _service = service;
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public void Add(NcmViewModel r)
        {
            var p = Mapper.Map<NcmViewModel, Ncm>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public NcmViewModel GetById(Guid id)
        {
            return Mapper.Map<Ncm, NcmViewModel>(_service.GetById(id));
        }

        public IEnumerable<NcmViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Ncm>, IEnumerable<NcmViewModel>>(_service.GetAll());
        }

        public void Update(NcmViewModel r)
        {
            var p = Mapper.Map<NcmViewModel, Ncm>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }

        public void Remove(NcmViewModel r)
        {
            var p = Mapper.Map<NcmViewModel, Ncm>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }
    }
}
