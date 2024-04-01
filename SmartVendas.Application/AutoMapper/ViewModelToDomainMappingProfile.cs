using AutoMapper;
using SmartVendas.Application.ViewModels;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<TipoProdutoViewModel, TipoProduto>();

            Mapper.CreateMap<PedidoViewModel, Pedido>();

            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<TipoUsuarioViewModel, TipoUsuario>();

            Mapper.CreateMap<ClienteViewModel, Cliente>();

            Mapper.CreateMap<VendaViewModel, Venda>();
            Mapper.CreateMap<TipoVendaViewModel, TipoVenda>();
            Mapper.CreateMap<ProdutoVendaViewModel, ProdutoVenda>();

            Mapper.CreateMap<UnidadeMedidaViewModel, UnidadeMedida>();
            Mapper.CreateMap<NcmViewModel, Ncm>();

            Mapper.CreateMap<CaixaViewModel, Caixa>();
            Mapper.CreateMap<LancamentoCaixaViewModel, LancamentoCaixa>();
        }
    }
}
