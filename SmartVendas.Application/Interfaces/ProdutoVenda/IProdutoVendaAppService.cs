using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface IProdutoVendaAppService : IDisposable
    {
        void Add(ProdutoVendaViewModel p);
        ProdutoVendaViewModel GetById(Guid id);
        IEnumerable<ProdutoVendaViewModel> GetAll();
        void Update(ProdutoVendaViewModel p);
        void Remove(ProdutoVendaViewModel p);
    }
}
