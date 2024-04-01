using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces 
{
    public interface IPedidoAppService : IDisposable
    {
    void Add(PedidoViewModel r);
    PedidoViewModel GetById(Guid id);
    IEnumerable<PedidoViewModel> GetAll();
    void Update(PedidoViewModel r);
    void Remove(PedidoViewModel r);
}
}
