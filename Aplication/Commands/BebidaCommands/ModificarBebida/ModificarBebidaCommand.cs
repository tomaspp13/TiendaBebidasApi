using MediatR;

namespace Aplication.Commands.BebidaCommands.ModificarBebida
{
    public class ModificarBebidaCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Cantidad { get; set; }
        public float Valor { get; set; }
        public string Moneda {  get; set; }
        public string NombreBuscado {  get; set; }
        public ModificarBebidaCommand(string nombre, float cantidad, float valor, string moneda, string nombreBuscado)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Valor = valor;
            Moneda = moneda;
            NombreBuscado = nombreBuscado;
        }
    }
}
