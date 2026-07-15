using Aplication.Exceptions;
using Aplication.Query.QueryBebidas.ObtenerBebidasPorId;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Query.QueryBebidas.ObtenerBebidas
{
    public class ObtenerBebidasHandler : IRequestHandler<ObtenerBebidasQuery, ICollection<ObtenerBebidasResponse>>
    {
        private readonly IBebidaRepository _repository;
        private readonly IMapper _mapper;

        public ObtenerBebidasHandler(IBebidaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ObtenerBebidasResponse>> Handle(ObtenerBebidasQuery request , CancellationToken cancellation)
        {
            ICollection<Bebida> todasBebidas = await _repository.TraerTodasLasBebidasAsync();
            if (todasBebidas == null) throw new InvalidBebidaException.BebidaNoEncontradaException();
            ICollection <ObtenerBebidasResponse> bebidas = _mapper.Map<ICollection<ObtenerBebidasResponse>>(todasBebidas);
            return bebidas;
        }

    }
}
