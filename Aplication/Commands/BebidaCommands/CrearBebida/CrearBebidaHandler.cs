using Aplication.Exceptions;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.BebidaCommands.CrearBebida
{
    public class CrearBebidaHandler : IRequestHandler<CrearBebidaCommand, CrearBebidaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBebidaRepository _repositorio;
        public CrearBebidaHandler(IMapper mapper,IBebidaRepository repositorio)
        {
            _mapper = mapper;
            _repositorio = repositorio;
        }
        public async Task<CrearBebidaResponse> Handle(CrearBebidaCommand request, CancellationToken cancellationToken)
        {
            var bebidaEncontrada = await _repositorio.BuscarBebidaPorNombreAsync(request.Nombre);
            if (bebidaEncontrada != null) throw new InvalidBebidaException.BebidaEncontradaException();

            var bebida = _mapper.Map<Bebida>(request);
            await _repositorio.CrearBebidaAsync(bebida);

            var response = _mapper.Map<CrearBebidaResponse>(bebida);
            return response;
        }

    }

}