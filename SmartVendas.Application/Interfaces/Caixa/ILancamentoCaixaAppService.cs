using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface ILancamentoCaixaAppService : IDisposable
    {
        void Add(LancamentoCaixaViewModel r);
        LancamentoCaixaViewModel GetById(Guid id);
        IEnumerable<LancamentoCaixaViewModel> GetAll();
        void Update(LancamentoCaixaViewModel r);
        void Remove(LancamentoCaixaViewModel r);
    }
}
