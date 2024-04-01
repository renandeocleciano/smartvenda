using Ninject.Modules;
using SmartVendas.Application.AppService;
using SmartVendas.Application.Interfaces;
using SmartVendas.Domain.Interfaces.Repositories;
using SmartVendas.Domain.Interfaces.Services;
using SmartVendas.Domain.Services;
using SmartVendas.Infra.Data.Context;
using SmartVendas.Infra.Data.Interfaces;
using SmartVendas.Infra.Data.Repositories;
using SmartVendas.Infra.Data.Repositories.ReadOnly;
using SmartVendas.Infra.Data.Repositories.Repository;
using SmartVendas.Infra.Data.UoW;

namespace SmartVendas.Infra.CrossCutting.Ioc
{
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            // app
            Bind<IProdutoAppService>().To<ProdutoAppService>();
            Bind<ITipoProdutoAppService>().To<TipoProdutoAppService>();
            Bind<ITipoUsuarioAppService>().To<TipoUsuarioAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();
            Bind<IClienteAppService>().To<ClienteAppService>();
            Bind<IVendaAppService>().To<VendaAppService>();
            Bind<ITipoVendaAppService>().To<TipoVendaAppService>();
            Bind<IProdutoVendaAppService>().To<ProdutoVendaAppService>();
            Bind<IPedidoAppService>().To<PedidoAppService>();
            Bind<IUnidadeMedidaAppService>().To<UnidadeMedidaAppService>();
            Bind<INcmAppService>().To<NcmAppService>();
            Bind<ICaixaAppService>().To<CaixaAppService>();
            Bind<ILancamentoCaixaAppService>().To<LancamentoCaixaAppService>();

            // service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IProdutoService>().To<ProdutoService>();
            Bind<ITipoProdutoService>().To<TipoProdutoService>();
            Bind<ITipoUsuarioService>().To<TipoUsuarioService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<IClienteService>().To<ClienteService>();
            Bind<IVendaService>().To<VendaService>();
            Bind<IProdutoVendaService>().To<ProdutoVendaService>();
            Bind<ITipoVendaService>().To<TipoVendaService>();
            Bind<IPedidoService>().To<PedidoService>();
            Bind<IUnidadeMedidaService>().To<UnidadeMedidaService>();
            Bind<INcmService>().To<NcmService>();
            Bind<ICaixaService>().To<CaixaService>();
            Bind<ILancamentoCaixaService>().To<LancamentoCaixaService>();


            // data repos
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<,>));
            Bind<IProdutoRepository>().To<ProdutoRepository>();
            Bind<ITipoProdutoRepository>().To<TipoProdutoRepository>();
            Bind<ITipoUsuarioRepository>().To<TipoUsuarioRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IVendaRepository>().To<VendaRepository>();
            Bind<IProdutoVendaRepository>().To<ProdutoVendaRepository>();
            Bind<ITipoVendaRepository>().To<TipoVendaRepository>();
            Bind<IPedidoRepository>().To<PedidoRepository>();
            Bind<IUnidadeMedidaRepository>().To<UnidadeMedidaRepository>();
            Bind<INcmRepository>().To<NcmRepository>();
            Bind<ICaixaRepository>().To<CaixaRepository>();
            Bind<ILancamentoCaixaRepository>().To<LancamentoCaixaRepository>();

            // data repos read only
            Bind<IProdutoReadOnlyRepository>().To<ProdutoReadOnlyRepository>();
            Bind<ITipoProdutoReadOnlyRepository>().To<TipoProdutoReadOnlyRepository>();
            Bind<IUsuarioReadOnlyRepository>().To<UsuarioReadOnlyRepository>();
            Bind<ITipoUsuarioReadOnlyRepository>().To<TipoUsuarioReadOnlyRepository>();
            Bind<IClienteReadOnlyRepository>().To<ClienteReadOnlyRepository>();
            Bind<IVendaReadOnlyRepository>().To<VendaReadOnlyRepository>();
            Bind<IProdutoVendaReadOnlyRepository>().To<ProdutoVendaReadOnlyRepository>();
            Bind<ITipoVendaReadOnlyRepository>().To<TipoVendaReadOnlyRepository>();
            Bind<IPedidoReadOnlyRepository>().To<PedidoReadOnlyRepository>();
            
            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<SmartVendasContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));

           
        }
    }
}
