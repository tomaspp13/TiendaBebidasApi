using Aplication.Exceptions;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Query.QueryUsuarios.ObtenerUsuarioPorId
{
    public class ObtenerUsuarioPorIdHandler : IRequestHandler<ObtenerUsuarioPorIdQuery, ObtenerUsuarioPorIdResponse>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        public ObtenerUsuarioPorIdHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ObtenerUsuarioPorIdResponse> Handle(ObtenerUsuarioPorIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.BuscarUsuarioPorIdAsync(request.Id);
            if (usuario == null) { throw new InvalidUsuarioException.UsuarioNoEncontrado(); }

            var usuarioMapeado = _mapper.Map<ObtenerUsuarioPorIdResponse>(usuario);
            return usuarioMapeado;
        }
    }
}
