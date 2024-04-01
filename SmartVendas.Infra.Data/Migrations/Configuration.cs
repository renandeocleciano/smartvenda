using SmartVendas.Domain.Entities;
using SmartVendas.Infra.Data.Context;

namespace SmartVendas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartVendasContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SmartVendasContext context)
        {
            context.TipoProduto.AddOrUpdate(new TipoProduto()
            {
                TipoProdutoId = new Guid("D03B8317-9DCD-4C61-81C5-B175C4998FE3"),
                Nome = "Comida",
                Ativo = true
            });

            context.TipoProduto.AddOrUpdate(new TipoProduto()
            {
                TipoProdutoId = new Guid("C3980EF8-3301-4EB1-9A23-4B1CEBE72D54"),
                Nome = "Lanches",
                Ativo = true
            });

            context.TipoProduto.AddOrUpdate(new TipoProduto()
            {
                TipoProdutoId = new Guid("B83A4013-975A-4084-B83F-294662154F23"),
                Nome = "Bebidas",
                Ativo = true
            });

            context.TipoProduto.AddOrUpdate(new TipoProduto()
            {
                TipoProdutoId = new Guid("6D3F9E3F-C344-4C19-BA5C-FBB56EEFAA11"),
                Nome = "Sobremesa",
                Ativo = true
            });

            context.TipoUsuario.AddOrUpdate(new TipoUsuario()
            {
                TipoUsuarioId = new Guid("0907D056-5B2E-4509-B01D-8D75F280FB37"),
                Nome = "Administrador",
                Ativo = true
            });

            context.TipoUsuario.AddOrUpdate(new TipoUsuario()
            {
                TipoUsuarioId = new Guid("817DB637-D7F9-4426-89F3-D31996A35E25"),
                Nome = "Vendedor",
                Ativo = true
            });

            context.Usuario.AddOrUpdate(new Usuario()
            {
                UsuarioId = new Guid("2C10406D-D15C-4537-908F-E950D3881C32"),
                TipoUsuarioId = new Guid("0907D056-5B2E-4509-B01D-8D75F280FB37"),
                Nome = "Administrador",
                Email = "smartvendas@rtsolucoesweb.com",
                UserName = "admin",
                Senha = "078354D7939D8B4EAD8E4528103F2366"
            });
            
            context.TipoVenda.AddOrUpdate(new TipoVenda()
            {
                Nome = "Dinheiro",
                TipoVendaId = new Guid("AC3A45AD-AA9A-409E-BD86-9E1EF9A0EE32"),
                Ativo = true
            });

            context.TipoVenda.AddOrUpdate(new TipoVenda()
            {
                Nome = "Débito",
                TipoVendaId = new Guid("1892BFA2-BABB-44B8-AECC-09897466E99F"),
                Ativo = true
            });

            context.TipoVenda.AddOrUpdate(new TipoVenda()
            {
                Nome = "Crédito",
                TipoVendaId = new Guid("C52CF806-286A-4BCE-9091-4903848A104A"),
                Ativo = true
            });

            context.UnidadeMedida.AddOrUpdate(new UnidadeMedida()
            {
                UnidadeMedidaId = new Guid("7CE270FA-0409-4B84-8C8A-1B88755A35AC"),
                Unidade = "UNID",
                Descricao = "UNIDADE",
                Ativo = true
            });

        }
    }
}
