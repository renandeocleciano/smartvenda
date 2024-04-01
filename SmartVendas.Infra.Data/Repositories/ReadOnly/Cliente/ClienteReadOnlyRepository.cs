using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class ClienteReadOnlyRepository : RepositoryBaseReadOnly, IClienteReadOnlyRepository
    {
        public IEnumerable<Cliente> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT * FROM Cliente
                            ORDER BY Nome asc";

                var clientes = cn.Query<Cliente>(sql);

                return clientes;
            }
        }


        public Cliente GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {

                var sql = @"Select * From Cliente c WHERE c.ClienteId = '"+ id + "'";
                cn.Open();
                var clientes = cn.Query<Cliente>(sql);
                return clientes.First();
            }
        }
    }
}
