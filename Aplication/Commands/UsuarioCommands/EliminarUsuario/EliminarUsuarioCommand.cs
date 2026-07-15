using MediatR;

namespace Aplication.Commands.UsuarioCommands.EliminarUsuario
{
    public class EliminarUsuarioCommand : IRequest
    {
        public Guid Id { get; set; }
        public EliminarUsuarioCommand(Guid id) {  this.Id = id;}
    }
}
