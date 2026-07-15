using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Query.QueryUsuarios.ObtenerUsuarioPorEmail
{
    public class ObtenerUsuarioPorEmailQuery : IRequest<ObtenerUsuarioPorEmailResponse>
    {
        public string Email { get;}
        public ObtenerUsuarioPorEmailQuery(string email) { this.Email = email; }
    }
}
