using MediatR;

namespace Aplication.Commands.UsuarioCommands.ModificarContraseñaUsuario
{
    public class ModificarContraseñaUsuarioCommand : IRequest
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public ModificarContraseñaUsuarioCommand(string contraseña,string email) { this.Contraseña = contraseña; this.Email = email; } 
    }
}
