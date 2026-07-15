using Aplication.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.UsuarioCommands.ModificarEmailUsuario
{
    public class ModificarEmailUsuarioHandler : IRequestHandler<ModificarEmailUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        public ModificarEmailUsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ModificarEmailUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.BuscarUsuarioPorEmailAsync(request.EmailViejo);
            if (usuario == null) { throw new InvalidUsuarioException.UsuarioNoEncontrado(); }

            usuario.ModificarEmailUsuario(request.EmailNuevo);
            await _repository.EditarUsuarioAsync(usuario);
        }
    }
}
