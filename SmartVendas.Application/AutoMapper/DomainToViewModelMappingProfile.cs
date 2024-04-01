using AutoMapper;
using SmartVendas.Application.ViewModels;
using SmartVendas.Domain.Entities;

namespace SmartVendas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<TipoProduto, TipoProdutoViewModel>();
            //.ForMember(dest => dest.ProdutoList, opt => opt.MapFrom(src => src.ProdutoList));

            Mapper.CreateMap<Pedido, PedidoViewModel>();

            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<TipoUsuario, TipoUsuarioViewModel>();
                //.ForMember(dest => dest.UsuarioList, opt => opt.MapFrom(src => src.UsuarioList));

            Mapper.CreateMap<Cliente, ClienteViewModel>();
                //.ForMember(dest => dest.ProdutosComprados, opt => opt.MapFrom(src => src.ProdutosComprados));

            Mapper.CreateMap<Venda, VendaViewModel>();
                //.ForMember(dest => dest.ProdutoList, opt => opt.MapFrom(src => src.ProdutoList));
            Mapper.CreateMap<TipoVenda, TipoVendaViewModel>();
            //.ForMember(dest => dest.VendaList, opt => opt.MapFrom(src => src.VendaList));
            Mapper.CreateMap<ProdutoVenda, ProdutoVendaViewModel>();

            Mapper.CreateMap<UnidadeMedida, UnidadeMedidaViewModel>();
            Mapper.CreateMap<Ncm, NcmViewModel>();

            Mapper.CreateMap<Caixa, CaixaViewModel>();
            Mapper.CreateMap<LancamentoCaixa, LancamentoCaixaViewModel>();
        }
    }
}
