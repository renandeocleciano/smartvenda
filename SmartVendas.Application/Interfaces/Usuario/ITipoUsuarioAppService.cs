using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface ITipoUsuarioAppService : IDisposable
    {
        void Add(TipoUsuarioViewModel r);
        TipoUsuarioViewModel GetById(Guid id);
        IEnumerable<TipoUsuarioViewModel> GetAll();
        void Update(TipoUsuarioViewModel r);
        void Remove(TipoUsuarioViewModel r);
    }
}
