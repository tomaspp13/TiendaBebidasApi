using MediatR;

namespace Aplication.Commands.UsuarioCommands.ModificarEmailUsuario
{
    public class ModificarEmailUsuarioCommand : IRequest
    {
        public string EmailViejo { get; set; }
        public string EmailNuevo {  get; set; }
        public ModificarEmailUsuarioCommand (string emailViejo, string emailNuevo) 
        {  
            this.EmailViejo = emailViejo;
            this.EmailNuevo = emailNuevo;
        }
    }
}
