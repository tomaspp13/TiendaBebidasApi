using MediatR;

namespace Aplication.Commands.BebidaCommands.CrearBebida
{
    public class CrearBebidaCommand : IRequest<CrearBebidaResponse>
    {
        public string Nombre { get;  }
        public float Cantidad { get; }
        public float Precio { get;}
        public string Moneda {  get; }

        public CrearBebidaCommand(string nombre, float cantidad, float precio, string moneda)
        {
            this.Nombre = nombre;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Moneda = moneda;
        }
    }
}
