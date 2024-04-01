using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface IVendaAppService: IDisposable
    {
        void Add(VendaViewModel r);
        VendaViewModel GetById(Guid id);
        IEnumerable<VendaViewModel> GetAll();
        void Update(VendaViewModel r);
        void Remove(VendaViewModel r);
    }
}
