using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface INcmAppService : IDisposable
    {
        void Add(NcmViewModel r);
        NcmViewModel GetById(Guid id);
        IEnumerable<NcmViewModel> GetAll();
        void Update(NcmViewModel r);
        void Remove(NcmViewModel r);
    }
}
