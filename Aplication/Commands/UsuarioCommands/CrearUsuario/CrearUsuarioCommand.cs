using MediatR;

namespace Aplication.Commands.UsuarioCommands.CrearUsuario
{
    public class CrearUsuarioCommand : IRequest<CrearUsuarioResponse>
    { 
        public string Nombre { get; set; }
        public string Apellido {  get; set; }
        public string Email {  get; set; }
        public string Contraseña { get; set; }

        public CrearUsuarioCommand(string nombre, string apellido, string email, string contraseña)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Contraseña = contraseña;
        }
    }
}
