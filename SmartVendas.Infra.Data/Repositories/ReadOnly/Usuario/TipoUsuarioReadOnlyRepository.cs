using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class TipoUsuarioReadOnlyRepository : RepositoryBaseReadOnly, ITipoUsuarioReadOnlyRepository
    {
        public IEnumerable<TipoUsuario> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TipoUsuario p ";
                var p = cn.Query<TipoUsuario>(sql);

                return p;
            }
        }

        public TipoUsuario GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TipoUsuario p " +
                          "WHERE p.TipoUsuarioId ='" + id + "'";

                var p = cn.Query<TipoUsuario>(sql);

                return p.FirstOrDefault();
            }
        }
    }
}
