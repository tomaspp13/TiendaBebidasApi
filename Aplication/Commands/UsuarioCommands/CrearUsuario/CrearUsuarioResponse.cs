namespace Aplication.Commands.UsuarioCommands.CrearUsuario
{
    public class CrearUsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }

        public CrearUsuarioResponse(Guid id,string nombre, string apellido, string email, string contraseña)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Contraseña = contraseña;

        }
        protected CrearUsuarioResponse() { }
    }
}
