using Domain.Entidades;

namespace Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task CrearUsuarioAsync(Usuario usuario);
        Task EditarUsuarioAsync(Usuario usuario);
        Task EliminarUsuarioAsync(Usuario usuario);
        Task <Usuario> BuscarUsuarioPorIdAsync(Guid id);
        Task<Usuario> BuscarUsuarioPorEmailAsync(string email);
    }
}
