using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class VendaReadOnlyRepository : RepositoryBaseReadOnly, IVendaReadOnlyRepository
    {
        public IEnumerable<Venda> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM Venda
                            ORDER BY Nome asc";

                var vendas = cn.Query<Venda>(sql);

                return vendas;
            }
        }

        public Venda GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
