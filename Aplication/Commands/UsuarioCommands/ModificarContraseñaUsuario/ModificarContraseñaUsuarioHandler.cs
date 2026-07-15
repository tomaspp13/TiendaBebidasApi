using Aplication.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.UsuarioCommands.ModificarContraseñaUsuario
{
    public class ModificarContraseñaUsuarioHandler : IRequestHandler<ModificarContraseñaUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        public ModificarContraseñaUsuarioHandler(IUsuarioRepository repository) => this._repository = repository;
        public async Task Handle(ModificarContraseñaUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.BuscarUsuarioPorEmailAsync(request.Email);
            if(usuario == null) { throw new InvalidUsuarioException.UsuarioNoEncontrado(); }

            usuario.IngresarContraseñaHasheada(request.Contraseña);
            await _repository.EditarUsuarioAsync(usuario);
        }
    }
}
