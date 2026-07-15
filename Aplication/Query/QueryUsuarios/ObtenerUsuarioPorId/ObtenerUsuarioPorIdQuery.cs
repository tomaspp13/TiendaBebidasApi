using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Query.QueryUsuarios.ObtenerUsuarioPorId
{
    public class ObtenerUsuarioPorIdQuery : IRequest<ObtenerUsuarioPorIdResponse>
    {
        public Guid Id { get;}
        public ObtenerUsuarioPorIdQuery(Guid id) {  this.Id = id;}
    }
}
