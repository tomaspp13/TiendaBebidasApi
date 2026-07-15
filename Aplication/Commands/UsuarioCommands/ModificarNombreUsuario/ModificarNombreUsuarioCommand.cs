using MediatR;

namespace Aplication.Commands.UsuarioCommands.ModificarNombreUsuario
{
    public class ModificarNombreUsuarioCommand : IRequest
    {
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public ModificarNombreUsuarioCommand(string nombre,string email, string apellido)
        {
            this.Email = email;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
    }
}
