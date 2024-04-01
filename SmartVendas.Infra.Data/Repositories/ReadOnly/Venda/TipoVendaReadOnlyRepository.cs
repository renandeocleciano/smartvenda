using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class TipoVendaReadOnlyRepository : RepositoryBaseReadOnly, ITipoVendaReadOnlyRepository
    {
        public IEnumerable<TipoVenda> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM TipoVenda
                            ORDER BY Nome asc";

                var tipoVendas = cn.Query<TipoVenda>(sql);

                return tipoVendas;
            }
        }

        public TipoVenda GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
