using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SmartVendas.Domain.Entities;
using SmartVendas.Domain.Interfaces.Repositories;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class UsuarioReadOnlyRepository : RepositoryBaseReadOnly, IUsuarioReadOnlyRepository
    {
        public IEnumerable<Usuario> GetAll()
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT p.*, f.Nome FROM Usuario p 
                            INNER JOIN TipoUsuario f ON p.TipoUsuarioId = f.TipoUsuarioId";

                var u = cn.Query<Usuario, TipoUsuario, Usuario>(
                    sql,
                    (p, f) =>
                    {
                        p.TipoUsuario = f;

                        return p;
                    }, splitOn: "UsuarioId, TipoUsuarioId");

                return u;
            }
        }

        public Usuario GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT p.*, f.Nome FROM Usuario p " +
                          "INNER JOIN TipoUsuario f ON p.TipoUsuarioId = f.TipoUsuarioId " +
                          "WHERE p.UsuarioId ='" + id + "'";

                var u = cn.Query<Usuario, TipoUsuario, Usuario>(
                    sql,
                    (p, f) =>
                    {
                        p.TipoUsuario = f;

                        return p;
                    }, splitOn: "UsuarioId, TipoUsuarioId");

                return u.FirstOrDefault();
            }
        }

        public Usuario GetByUserAndPass(string username, string pass)
        {
            using (IDbConnection cn = Connection)
            {
                cn.Open();

                var sql = @"SELECT p.*, f.Nome FROM Usuario p " +
                          "INNER JOIN TipoUsuario f ON p.TipoUsuarioId = f.TipoUsuarioId " +
                          "WHERE p.UserName ='" + username + "' and p.Senha ='" + pass + "'";

                var u = cn.Query<Usuario, TipoUsuario, Usuario>(
                    sql,
                    (p, f) =>
                    {
                        p.TipoUsuario = f;

                        return p;
                    }, splitOn: "UsuarioId, TipoUsuarioId");

                return u.FirstOrDefault();
            }
        }
    }
}
