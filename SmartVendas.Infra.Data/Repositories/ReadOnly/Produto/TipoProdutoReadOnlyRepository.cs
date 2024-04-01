using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class TipoProdutoReadOnlyRepository : RepositoryBaseReadOnly, ITipoProdutoReadOnlyRepository
    {
        public TipoProduto GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TipoProduto p " +
                          "WHERE p.TipoProdutoId ='" + id + "'";

                var p = cn.Query<TipoProduto>(sql);

                return p.FirstOrDefault();
            }
        }

        public IEnumerable<TipoProduto> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"Select * From TipoProduto p ";
                var p = cn.Query<TipoProduto>(sql);

                return p;
            }
        }
    }
}
