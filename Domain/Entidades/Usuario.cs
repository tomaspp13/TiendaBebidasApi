using Domain.ValueObjects;

namespace Domain.Entidades
{
    public class Usuario : BaseEntity
    {
        public NombreCompleto Nombre{ get; private set; }
        public Email EmailUsuario{ get; private set; }
        public Contraseña ContraseñaUsuario { get; private set; }
        public Usuario(NombreCompleto nombre, Email emailUsuario, Contraseña contraseñaUsuario)
        {
            this.Nombre = nombre;
            this.EmailUsuario = emailUsuario;
            this.ContraseñaUsuario = contraseñaUsuario;
        }
        protected Usuario() { }
        public void ModificarNombreUsuario(string nombre, string apellido) => this.Nombre = new NombreCompleto(nombre, apellido);
        public void ModificarEmailUsuario(string email) => this.EmailUsuario = new Email(email);
        public void IngresarContraseñaHasheada(string contraseñaHasheada) => this.ContraseñaUsuario = new Contraseña(contraseñaHasheada); 
    }
}
