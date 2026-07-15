using Aplication.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.UsuarioCommands.ModificarNombreUsuario
{
    public class ModificarNombreUsuarioHandler : IRequestHandler<ModificarNombreUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public ModificarNombreUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task Handle(ModificarNombreUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPorEmailAsync(request.Email);
            if (usuario == null) { throw new InvalidUsuarioException.UsuarioNoEncontrado(); }

            usuario.ModificarNombreUsuario(request.Nombre, request.Apellido);
            await _usuarioRepository.EditarUsuarioAsync(usuario);
        }
    }
}
