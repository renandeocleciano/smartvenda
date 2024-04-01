using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface IUnidadeMedidaAppService : IDisposable
    {
        void Add(UnidadeMedidaViewModel r);
        UnidadeMedidaViewModel GetById(Guid id);
        IEnumerable<UnidadeMedidaViewModel> GetAll();
        void Update(UnidadeMedidaViewModel r);
        void Remove(UnidadeMedidaViewModel r);
    }
}
