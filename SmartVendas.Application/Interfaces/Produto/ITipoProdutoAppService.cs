using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface ITipoProdutoAppService : IDisposable
    {
        void Add(TipoProdutoViewModel p);
        TipoProdutoViewModel GetById(Guid id);
        IEnumerable<TipoProdutoViewModel> GetAll();
        void Update(TipoProdutoViewModel p);
        void Remove(TipoProdutoViewModel p);
    }
}
