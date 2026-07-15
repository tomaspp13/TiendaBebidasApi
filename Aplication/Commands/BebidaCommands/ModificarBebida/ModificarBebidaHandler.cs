using Aplication.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.BebidaCommands.ModificarBebida
{
    public class ModificarBebidaHandler : IRequestHandler<ModificarBebidaCommand>
    {
        private readonly IBebidaRepository _repository;

        public ModificarBebidaHandler(IBebidaRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ModificarBebidaCommand request, CancellationToken cancellation)
        {

            var bebida = await _repository.BuscarBebidaPorNombreAsync(request.NombreBuscado);

            if(bebida != null) {

                bebida.modificarNombreBebida(request.Nombre);
                bebida.modificarPrecioBebida(request.Valor, request.Moneda);
                bebida.modificarCantidadBebida(request.Cantidad);
                await _repository.ModificarBebidaAsync(bebida);
                return; 
            }

            throw new InvalidBebidaException.BebidaNoEncontradaException();
        }
    }
}
