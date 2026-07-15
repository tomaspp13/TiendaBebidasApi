using MediatR;

namespace Aplication.Commands.BebidaCommands.CrearBebida
{
    public class CrearBebidaCommand : IRequest<CrearBebidaResponse>
    {
        public string Nombre { get; set; }
        public float Cantidad { get; set; }
        public float Precio { get; set; }
        public string Moneda {  get; set; }

        public CrearBebidaCommand(string nombre, float cantidad, float precio, string moneda)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Moneda = moneda;
        }
    }
}
