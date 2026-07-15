using Domain.Entidades;

namespace Domain.Interfaces.Repositories
{
    public interface IBebidaRepository
    {
        Task CrearBebidaAsync(Bebida bebida);
        Task <Bebida> BuscarBebidaPorIdAsync(Guid id);
        Task <ICollection<Bebida>> TraerTodasLasBebidasAsync();
        Task EliminarBebidaAsync(Bebida bebida);
        Task ModificarBebidaAsync(Bebida bebida);
        Task <Bebida> BuscarBebidaPorNombreAsync(string nombre);
    }
}
