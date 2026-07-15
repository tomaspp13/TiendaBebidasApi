using MediatR;

namespace Aplication.Commands.BebidaCommands.EliminarBebida
{
    public class EliminarBebidaCommand : IRequest
    {
        public string Nombre { get; set; }

        public EliminarBebidaCommand(string nombre) =>  this.Nombre = nombre; 
    }
}
