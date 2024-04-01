using System;
using System.Linq;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Infra.Data.Context;

namespace SmartVendas.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario, SmartVendasContext>, IUsuarioRepository
    {
        public Usuario GetByUserAndPass(string username, string pass)
        {
            return base.Find(c => c.UserName == username && c.Senha == pass).FirstOrDefault();
        }
    }
}
