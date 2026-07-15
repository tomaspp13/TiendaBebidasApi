using MediatR;

namespace Aplication.Commands.BebidaCommands.EliminarBebida
{
    public class EliminarBebidaCommand : IRequest
    {
        public string Nombre { get;}

        public EliminarBebidaCommand(string nombre) =>  this.Nombre = nombre; 
    }
}
