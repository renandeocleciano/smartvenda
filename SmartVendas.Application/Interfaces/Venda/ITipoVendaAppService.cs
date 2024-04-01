using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface ITipoVendaAppService : IDisposable
    {
        void Add(TipoVendaViewModel r);
        TipoVendaViewModel GetById(Guid id);
        IEnumerable<TipoVendaViewModel> GetAll();
        void Update(TipoVendaViewModel r);
        void Remove(TipoVendaViewModel r);
    }
}
