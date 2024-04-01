using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class ProdutoReadOnlyRepository : RepositoryBaseReadOnly, IProdutoReadOnlyRepository
    {
        public Produto GetByIdReadOnly(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT p.*, f.*, u.*, n.* FROM Produto p " +
                          "INNER JOIN TipoProduto f ON p.TipoProdutoId = f.TipoProdutoId " +
                          "INNER JOIN UnidadeMedida u ON p.UnidadeMedidaId = u.UnidadeMedidaId " +
                          "INNER JOIN Ncm n ON p.NcmId = n.NcmId " +
                          "WHERE p.ProdutoId ='" + id + "'";

                var produto = cn.Query<Produto, TipoProduto, UnidadeMedida, Ncm, Produto>(
                     sql,
                     (p, f, u, n) =>
                     {
                         p.TipoProduto = f;
                         p.UnidadeMedida = u;
                         p.Ncm = n;
                         return p;
                     }, splitOn: "ProdutoId, TipoProdutoId, UnidadeMedidaId, NcmId");

                return produto.FirstOrDefault();
            }
        }

        public IEnumerable<Produto> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT p.*, f.*, u.*, n.* FROM Produto p 
                            INNER JOIN TipoProduto f ON p.TipoProdutoId = f.TipoProdutoId 
                            INNER JOIN UnidadeMedida u ON p.UnidadeMedidaId = u.UnidadeMedidaID 
                            INNER JOIN Ncm n ON p.NcmId = n.NcmId ";

                var produto = cn.Query<Produto, TipoProduto, UnidadeMedida, Ncm, Produto>(
                    sql,
                    (p, f, u, n) =>
                    {
                        p.TipoProduto = f;
                        p.UnidadeMedida = u;
                        p.Ncm = n;
                        return p;
                    }, splitOn: "ProdutoId, TipoProdutoId, UnidadeMedidaId, NcmId");

                return produto;
            }
        }
    }
}
