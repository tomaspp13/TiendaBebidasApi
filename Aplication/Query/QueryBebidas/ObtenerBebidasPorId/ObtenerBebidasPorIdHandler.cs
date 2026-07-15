using Aplication.Exceptions;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Query.QueryBebidas.ObtenerBebidasPorId
{
    public class ObtenerBebidasPorIdHandler : IRequestHandler<ObtenerBebidasPorIdQuery,ObtenerBebidasPorIdResponse>
    {

        private readonly IBebidaRepository _repository;
        private readonly IMapper _mapper;

        public ObtenerBebidasPorIdHandler(IBebidaRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ObtenerBebidasPorIdResponse> Handle(ObtenerBebidasPorIdQuery request,CancellationToken cancellation)
        {
            var bebidaFiltrada = await _repository.BuscarBebidaPorIdAsync(request.Id);            
            if (bebidaFiltrada == null)  throw new InvalidBebidaException.BebidaNoEncontradaException();                
            var bebida = _mapper.Map<ObtenerBebidasPorIdResponse>(bebidaFiltrada);

            return bebida;
        }

    }
}
