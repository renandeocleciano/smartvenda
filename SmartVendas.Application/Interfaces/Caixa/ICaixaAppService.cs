using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface ICaixaAppService : IDisposable
    {
        void Add(CaixaViewModel r);
        CaixaViewModel GetById(Guid id);
        IEnumerable<CaixaViewModel> GetAll();
        void Update(CaixaViewModel r);
        void Remove(CaixaViewModel r);
        CaixaViewModel GetOpened();
    }
}
