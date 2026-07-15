
namespace Domain.ValueObjects
{
    public class NombreCompleto
    {
        public string Nombre { get; }
        public string Apellido {  get; }

        public NombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrEmpty(nombre)) throw new Exception("El nombre no puede estar vacio");
            if (string.IsNullOrEmpty(apellido)) throw new Exception("El apellido no puede estar vacio");

            this.Nombre = nombre;
            this.Apellido = apellido;
        }
        protected NombreCompleto() { }
    }
}
