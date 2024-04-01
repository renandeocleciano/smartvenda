using SmartVendas.Domain.Entities;

namespace SmartVendas.Domain.Interfaces.Services
{
    public interface IUsuarioService: IServiceBase<Usuario>
    {
        Usuario GetByUserAndPass(string username, string pass);
    }
}
