using Aplication.Exceptions;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.BebidaCommands.EliminarBebida
{
    public class EliminarBebidaHandler : IRequestHandler<EliminarBebidaCommand>
    {

        private readonly IBebidaRepository _repository;

        public EliminarBebidaHandler(IBebidaRepository repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task Handle(EliminarBebidaCommand request, CancellationToken cancellation)
        {
            var bebida = await _repository.BuscarBebidaPorNombreAsync(request.Nombre);
            if (bebida == null) throw new InvalidBebidaException.BebidaNoEncontradaException();
            await _repository.EliminarBebidaAsync(bebida);    
        }

    }
}
