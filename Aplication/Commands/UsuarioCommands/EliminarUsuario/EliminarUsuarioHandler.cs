using Aplication.Exceptions;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Aplication.Commands.UsuarioCommands.EliminarUsuario
{
    public class EliminarUsuarioHandler : IRequestHandler<EliminarUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;
        public EliminarUsuarioHandler(IUsuarioRepository repository) { _repository = repository; }
        public async Task Handle(EliminarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _repository.BuscarUsuarioPorIdAsync(request.Id);
            if (usuario == null) { throw new InvalidUsuarioException.UsuarioNoEncontrado(); }
            await _repository.EliminarUsuarioAsync(usuario);
        }
    }
}
