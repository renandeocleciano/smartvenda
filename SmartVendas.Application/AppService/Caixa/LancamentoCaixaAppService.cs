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
    public class LancamentoCaixaAppService : AppServiceBase<SmartVendasContext>, ILancamentoCaixaAppService
    {
        private readonly ILancamentoCaixaService _service;

        public LancamentoCaixaAppService(ILancamentoCaixaService service)
        {
            _service = service;
        }

        public void Dispose()
        {
            _service.Dispose();
        }

        public void Add(LancamentoCaixaViewModel r)
        {
            var p = Mapper.Map<LancamentoCaixaViewModel, LancamentoCaixa>(r);
            BeginTransaction();
            _service.Add(p);
            Commit();
        }

        public LancamentoCaixaViewModel GetById(Guid id)
        {
            return Mapper.Map<LancamentoCaixa, LancamentoCaixaViewModel>(_service.GetById(id));
        }

        public IEnumerable<LancamentoCaixaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<LancamentoCaixa>, IEnumerable<LancamentoCaixaViewModel>>(_service.GetAll());
        }

        public void Update(LancamentoCaixaViewModel r)
        {
            var p = Mapper.Map<LancamentoCaixaViewModel, LancamentoCaixa>(r);
            BeginTransaction();
            _service.Update(p);
            Commit();
        }

        public void Remove(LancamentoCaixaViewModel r)
        {
            var p = Mapper.Map<LancamentoCaixaViewModel, LancamentoCaixa>(r);
            BeginTransaction();
            _service.Remove(p);
            Commit();
        }
    }
}
