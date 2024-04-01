using System;
using System.Collections.Generic;
using SmartVendas.Application.ViewModels;

namespace SmartVendas.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        void Add(UsuarioViewModel r);
        UsuarioViewModel GetById(Guid id);
        IEnumerable<UsuarioViewModel> GetAll();
        void Update(UsuarioViewModel r);
        void Remove(UsuarioViewModel r);
        UsuarioViewModel GetByUserAndPass(string username, string pass);
    }
}
