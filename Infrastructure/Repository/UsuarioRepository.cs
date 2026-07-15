using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;  
        public UsuarioRepository(AppDbContext context) { _context = context; }
        public async Task CrearUsuarioAsync(Usuario usuario) 
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task EditarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario> BuscarUsuarioPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<Usuario> BuscarUsuarioPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.EmailUsuario.EmailNombre == (email));
        }
    }
}
