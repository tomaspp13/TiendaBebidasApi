using Aplication.Exceptions;
using AutoMapper;
using Domain.Entidades;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNet.Identity;

namespace Aplication.Commands.UsuarioCommands.CrearUsuario
{
    public class CrearUsuarioHandler : IRequestHandler<CrearUsuarioCommand,CrearUsuarioResponse>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _hasher;

        public CrearUsuarioHandler(IUsuarioRepository repository, IMapper mapper,IPasswordHasher hasher) 
        { 
            this._repository = repository; 
            this._mapper = mapper; 
            this._hasher = hasher;
        }

        public async Task<CrearUsuarioResponse> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarioFiltrado = await _repository.BuscarUsuarioPorEmailAsync(request.Email);
            if (usuarioFiltrado != null) { throw new InvalidUsuarioException.UsuarioEncontradoPorMail(); }

            string contraseñaHasheada = _hasher.HashPassword(request.Contraseña);

            var usuarioMapeado = _mapper.Map<Usuario>(request);
            usuarioMapeado.IngresarContraseñaHasheada(contraseñaHasheada);
            await _repository.CrearUsuarioAsync(usuarioMapeado);

            var usuarioResponseMapeado = _mapper.Map<CrearUsuarioResponse>(request);
            usuarioResponseMapeado.Id = usuarioMapeado.Id;
            return usuarioResponseMapeado;
        }
    }
}
