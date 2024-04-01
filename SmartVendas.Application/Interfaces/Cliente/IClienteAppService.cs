using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        void Add(ClienteViewModel r);
        ClienteViewModel GetById(Guid id);
        IEnumerable<ClienteViewModel> GetAll();
        void Update(ClienteViewModel r);
        void Remove(ClienteViewModel r);
    }
}
