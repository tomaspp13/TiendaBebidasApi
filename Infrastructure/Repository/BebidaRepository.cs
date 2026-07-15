using Domain.Entidades;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BebidaRepository : IBebidaRepository
    {
        private readonly AppDbContext _context;

        public BebidaRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<Bebida> BuscarBebidaPorIdAsync(Guid id)
        {
            var bebida = await _context.Bebidas.FindAsync(id);
            return bebida;
        }

        public async Task EliminarBebidaAsync(Bebida bebida)
        {
            _context.Bebidas.Remove(bebida);
            await _context.SaveChangesAsync();
        }

        public async Task CrearBebidaAsync(Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarBebidaAsync(Bebida bebida)
        {
            _context.Update(bebida);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Bebida>> TraerTodasLasBebidasAsync()
        {
            return await _context.Bebidas.ToListAsync();            
        }

        public async Task<Bebida> BuscarBebidaPorNombreAsync(string nombre)
        {
            return await _context.Bebidas.FirstOrDefaultAsync(b => b.Nombre == nombre);            
        }

    }
}
