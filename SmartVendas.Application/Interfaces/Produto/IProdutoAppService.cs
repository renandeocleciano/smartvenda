using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        void Add(ProdutoViewModel produtoViewModel);
        ProdutoViewModel GetById(Guid id);
        ProdutoViewModel GetByIdReadOnly(Guid id);
        IEnumerable<ProdutoViewModel> GetAll();
        void Update(ProdutoViewModel produtoViewModel);
        void Remove(ProdutoViewModel produtoViewModel);
        IEnumerable<ProdutoViewModel> BuscarPorNome(string nome);
    }
}
