using SmartVendas.Domain.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using SmartVendas.Infra.Data.EntityConfig;

namespace SmartVendas.Infra.Data.Context
{
    public class SmartVendasContext : BaseDbContext
    {
        public SmartVendasContext()
                    : base("SmartVendas")
        {

        }


        #region CadastroGeral
        public IDbSet<UnidadeMedida> UnidadeMedida { get; set; }
        public IDbSet<Ncm> Ncm { get; set; }
        #endregion

        #region Caixa
        public IDbSet<Caixa> Caixa { get; set; }
        public IDbSet<LancamentoCaixa> LancamentoCaixa { get; set; }

        #endregion

        #region Cliente
        public IDbSet<Cliente> Cliente { get; set; }
        #endregion

        #region Nfce
        public IDbSet<Duplicata> Duplicata { get; set; }
        public IDbSet<DadosNota> DadosNota { get; set; }
        public IDbSet<DadosItens> DadosItens { get; set; }
        #endregion

        #region Pedido
        public IDbSet<Pedido> Pedido { get; set; }
        #endregion

        #region Produto
        public IDbSet<Produto> Produtos { get; set; }
        public IDbSet<TipoProduto> TipoProduto { get; set; }
        #endregion

        #region ProdutoVenda
        public IDbSet<ProdutoVenda> ProdutoVenda { get; set; }
        #endregion

        #region Usuario
        public IDbSet<Usuario> Usuario { get; set; }
        public IDbSet<TipoUsuario> TipoUsuario { get; set; }
        #endregion

        #region Venda
        public IDbSet<TipoVenda> TipoVenda { get; set; }
        public IDbSet<Venda> Venda { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfigutarion());
            modelBuilder.Configurations.Add(new CaixaConfiguration());
            modelBuilder.Configurations.Add(new LancamentoCaixaConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new TipoProdutoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoVendaConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new TipoUsuarioConfiguration());
            modelBuilder.Configurations.Add(new TipoVendaConfiguration());
            modelBuilder.Configurations.Add(new VendaConfiguration());
            modelBuilder.Configurations.Add(new DadosItensConfiguration());
            modelBuilder.Configurations.Add(new DadosNotaConfiguration());
            modelBuilder.Configurations.Add(new DuplicataConfiguration());
            modelBuilder.Configurations.Add(new UnidadeMedidaConfiguration());
            modelBuilder.Configurations.Add(new NcmConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
