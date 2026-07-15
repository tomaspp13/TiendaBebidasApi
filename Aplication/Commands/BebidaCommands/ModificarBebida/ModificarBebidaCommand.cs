using MediatR;

namespace Aplication.Commands.BebidaCommands.ModificarBebida
{
    public class ModificarBebidaCommand : IRequest
    {
        public Guid Id { get; }
        public string Nombre { get; }
        public float Cantidad { get; }
        public float Valor { get; }
        public string Moneda {  get; }
        public string NombreBuscado {  get; }
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
